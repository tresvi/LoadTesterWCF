using System;
using System.Collections.Generic;
using System.Linq;
using ClienteHCS_2.Helpers;
using ClienteHCS_2.Models.LoadTest;

namespace ClienteHCS_2
{
    /// <summary>
    /// Modelo del reporte final de una prueba de carga.
    /// Contiene todos los campos que se muestran en el resumen y se exportan a CSV/JSON.
    /// </summary>
    public class LoadTestReport
    {
        public DateTime Fecha { get; set; }
        public string Servidor { get; set; } = "";
        public string TxFile { get; set; } = "";
        public int TotalHilos { get; set; }
        /// <summary>Tiempo entre transmisiones (ms) configurado en el ensayo.</summary>
        public int PausaMs { get; set; }
        public int FinalizadosOK { get; set; }
        public int FinalizadosFAIL { get; set; }
        public long TransmisionesSinRespuesta { get; set; }
        public long TransmisionesCompletadas { get; set; }
        public long TiempoMs { get; set; }
        public double ThroughputTrxSeg { get; set; }
        public long LatenciaMinMs { get; set; }
        public long LatenciaMaxMs { get; set; }
        public long LatenciaPromMs { get; set; }
        public long LatenciaP50Ms { get; set; }
        public long LatenciaP90Ms { get; set; }
        public long LatenciaP95Ms { get; set; }
        public long LatenciaP99Ms { get; set; }
        /// <summary>
        /// Array ordenado de latencias (ms) de todas las respuestas exitosas. Opcional, para análisis detallado.
        /// </summary>
        public long[] LatenciasOrdenadas { get; set; } = Array.Empty<long>();

        /// <summary>Throughput total / Nro de hilos OK (trx/seg por hilo).</summary>
        public double ThroughputPorHilo { get; set; }

        /// <summary>Tasa de éxito de hilos: FinalizadosOK / TotalHilos en 0-100%.</summary>
        public double TasaExitoHilos { get; set; }

        /// <summary>Estabilidad de latencia: 1 / (1 + σ), con σ = desvío estándar de las latencias promedio por hilo.</summary>
        public double EstabilidadLatencia { get; set; }

        /// <summary>Tasa de éxito de transacciones: TransmisionesCompletadas / TotalTransmisiones en 0-100%.</summary>
        public double TasaExitoTransacciones { get; set; }

        /// <summary>Consistencia de rendimiento: 1 / (1 + CV), con CV = coeficiente de variación del throughput por hilo.</summary>
        public double ConsistenciaRendimiento { get; set; }

        /// <summary>Base del Correlation ID (primeros 2 segmentos sin el número de hilo).</summary>
        public string CorrelationIDBase { get; set; } = "";

        /// <summary>
        /// Timestamps de transacciones exitosas (segundo relativo + nro de hilo).
        /// Se usa para graficar throughput en función del tiempo.
        /// </summary>
        public List<TrxTimestamp> Timestamps { get; set; } = new List<TrxTimestamp>();

        /// <summary>
        /// Reporte de salud del cliente durante el ensayo (CPU, memoria, ThreadPool, GC).
        /// Null si no se capturó (ej. ensayos antiguos cargados desde archivo).
        /// </summary>
        public ClientHealthReport SaludCliente { get; set; }

        /// <summary>
        /// Crea y calcula un reporte a partir de los datos de la prueba.
        /// Recibe una copia de la definición del ensayo (no se modifica el original).
        /// Las colecciones se reciben por referencia (IEnumerable); no se copian.
        /// </summary>
        public static LoadTestReport Create(
            IEnumerable<long> latencias,
            IEnumerable<LoadTestThreadItem> hilos,
            LoadTestDefinition loadTestDefinition,
            int finalizadosOK,
            int finalizadosFAIL,
            long transmisionesSinRespuesta,
            long transmisionesCompletadas,
            long tiempoMs,
            DateTime? fecha = null,
            string correlationIDBase = null,
            IEnumerable<TrxTimestamp> timestamps = null,
            ClientHealthReport clientHealth = null)
        {
            if (loadTestDefinition == null) throw new ArgumentNullException(nameof(loadTestDefinition));
            var def = loadTestDefinition;

            var fechaVal = fecha ?? DateTime.Now;
            double tiempoSeg = tiempoMs / 1000.0;
            double throughput = tiempoSeg > 0 ? transmisionesCompletadas / tiempoSeg : 0;

            // Una sola materialización del array ordenado (reutilizado para percentiles y LatenciasOrdenadas)
            long[] latenciasOrdenadas = latencias.OrderBy(x => x).ToArray();
            long latMin = 0, latMax = 0, latProm = 0, p50 = 0, p90 = 0, p95 = 0, p99 = 0;
            if (latenciasOrdenadas.Length > 0)
            {
                latMin = latenciasOrdenadas[0];
                latMax = latenciasOrdenadas[latenciasOrdenadas.Length - 1];
                latProm = (long)latenciasOrdenadas.Average();
                p50 = StatisticsHelper.Percentil(latenciasOrdenadas, 50);
                p90 = StatisticsHelper.Percentil(latenciasOrdenadas, 90);
                p95 = StatisticsHelper.Percentil(latenciasOrdenadas, 95);
                p99 = StatisticsHelper.Percentil(latenciasOrdenadas, 99);
            }

            // Latencias promedio por hilo: una sola iteración sobre hilos (sin copiar la colección de hilos)
            var latenciasPorHilo = hilos.Where(h => h.LatAvg >= 0).Select(h => (double)h.LatAvg).ToList();
            double sigma = StatisticsHelper.DesvioEstandar(latenciasPorHilo);
            double estabilidadLatencia = latenciasPorHilo.Count >= 2 ? StatisticsHelper.EstabilidadLatencia(sigma, StatisticsHelper.K_ESTABILIDAD_MS_DEFAULT) : 1.0;

            // Calcular tasa de éxito de transacciones
            long totalTransmisiones = transmisionesCompletadas + transmisionesSinRespuesta;
            double tasaExitoTransacciones = totalTransmisiones > 0 
                ? (transmisionesCompletadas * 100.0 / totalTransmisiones) 
                : 0;

            // Calcular consistencia de rendimiento (coeficiente de variación del throughput por hilo)
            var throughputsPorHilo = hilos.Where(h => h.StatusOk && h.ThroughputOK > 0)
                .Select(h => h.ThroughputOK).ToList();
            double consistenciaRendimiento = 1.0;
            if (throughputsPorHilo.Count >= 2)
            {
                double avgThroughput = throughputsPorHilo.Average();
                double sigmaThroughput = StatisticsHelper.DesvioEstandar(throughputsPorHilo);
                double cv = avgThroughput > 0 ? sigmaThroughput / avgThroughput : 0;
                // Normalizar: 1 / (1 + CV) -> valores más altos = más consistente
                consistenciaRendimiento = 1.0 / (1.0 + cv);
            }

            return new LoadTestReport
            {
                Fecha = fechaVal,
                Servidor = def.Server ?? "",
                TxFile = def.TxFile ?? "",
                TotalHilos = def.NroHilos,
                PausaMs = def.PausaMs,
                FinalizadosOK = finalizadosOK,
                FinalizadosFAIL = finalizadosFAIL,
                TransmisionesSinRespuesta = transmisionesSinRespuesta,
                TransmisionesCompletadas = transmisionesCompletadas,
                TiempoMs = tiempoMs,
                ThroughputTrxSeg = throughput,
                LatenciaMinMs = latMin,
                LatenciaMaxMs = latMax,
                LatenciaPromMs = latProm,
                LatenciaP50Ms = p50,
                LatenciaP90Ms = p90,
                LatenciaP95Ms = p95,
                LatenciaP99Ms = p99,
                LatenciasOrdenadas = latenciasOrdenadas,
                ThroughputPorHilo = finalizadosOK > 0 ? throughput / finalizadosOK : 0,
                TasaExitoHilos = loadTestDefinition.NroHilos > 0 ? (finalizadosOK * 100.0 / loadTestDefinition.NroHilos) : 0,
                EstabilidadLatencia = estabilidadLatencia,
                TasaExitoTransacciones = tasaExitoTransacciones,
                ConsistenciaRendimiento = consistenciaRendimiento,
                CorrelationIDBase = correlationIDBase ?? "",
                Timestamps = timestamps != null ? timestamps.ToList() : new List<TrxTimestamp>(),
                SaludCliente = clientHealth
            };
        }


        /// <summary>Genera el resumen en texto para mostrar en MessageBox o similar.</summary>
        public override string ToString()
        {
            string msgLat = LatenciasOrdenadas != null && LatenciasOrdenadas.Length > 0
                ? $"Latencia (ms): min {LatenciaMinMs} | max {LatenciaMaxMs} | prom {LatenciaPromMs} | p50 {LatenciaP50Ms} | p90 {LatenciaP90Ms} | p95 {LatenciaP95Ms} | p99 {LatenciaP99Ms}"
                : "Latencia: sin datos (no hubo respuestas exitosas)";

            string health = "";
            if (SaludCliente != null)
            {
                health = $"\n--- Salud del cliente ---" +
                    $"\nCPU: avg {SaludCliente.CpuAvgPercent:F1}% | max {SaludCliente.CpuMaxPercent:F1}%" +
                    $"\nMemoria: avg {SaludCliente.MemoryAvgMB:F0} MB | max {SaludCliente.MemoryMaxMB:F0} MB" +
                    $"\nGC: Gen0={SaludCliente.GcGen0Total} | Gen1={SaludCliente.GcGen1Total} | Gen2={SaludCliente.GcGen2Total}";
                if (SaludCliente.Saturado)
                    health += $"\n⚠ CLIENTE SATURADO: los resultados pueden no ser confiables." +
                              $"\n{SaludCliente.DetalleSaturacion}";
            }

            return
                $"\nTotal Hilos: {TotalHilos}" +
                $"\nTiempo entre transmisiones: {PausaMs} ms" +
                $"\nFinalizados OK: {FinalizadosOK} | Finalizados FAIL: {FinalizadosFAIL}" +
                $"\nTransmisiones completadas (respuesta servidor): {TransmisionesCompletadas}" +
                $"\nTransmisiones sin respuesta (error/timeout): {TransmisionesSinRespuesta}" +
                $"\nTiempo: {TiempoMs} ms" +
                $"\nThroughput: {ThroughputTrxSeg:F2} trx/seg" +
                $"\n{msgLat}" +
                $"\nThroughput por hilo: {ThroughputPorHilo:F2} trx/seg" +
                $"\nTasa éxito hilos: {TasaExitoHilos:F1}%" +
                $"\nEstabilidad latencia: {EstabilidadLatencia:F4}" +
                $"\nTasa éxito transacciones: {TasaExitoTransacciones:F1}%" +
                $"\nConsistencia rendimiento: {ConsistenciaRendimiento:F4}" +
                health;
        }
    }
}
