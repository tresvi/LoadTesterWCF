using System;
using System.Globalization;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace ClienteHCS_2.Helpers
{
    /// <summary>
    /// Exportación de <see cref="LoadTestReport"/> a CSV y JSON.
    /// </summary>
    public static class LoadTestReportExporter
    {
        private static readonly JsonSerializerSettings JsonSettings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            DateFormatString = "yyyy-MM-dd HH:mm:ss",
            NullValueHandling = NullValueHandling.Ignore
        };
        /// <summary>Exporta el reporte a un archivo CSV (Campo,Valor).</summary>
        public static void ExportarCsv(LoadTestReport r, string path)
        {
            if (r == null) return;
            var sb = new StringBuilder();
            sb.AppendLine("Campo,Valor");
            sb.AppendLine($"Fecha,{r.Fecha:yyyy-MM-dd HH:mm:ss}");
            sb.AppendLine($"Servidor,{r.Servidor}");
            sb.AppendLine($"TxFile,{r.TxFile}");
            sb.AppendLine($"Total Hilos,{r.TotalHilos}");
            sb.AppendLine($"Pausa entre transmisiones (ms),{r.PausaMs}");
            sb.AppendLine($"Finalizados OK,{r.FinalizadosOK}");
            sb.AppendLine($"Finalizados FAIL,{r.FinalizadosFAIL}");
            sb.AppendLine($"Transmisiones sin respuesta,{r.TransmisionesSinRespuesta}");
            sb.AppendLine($"Transmisiones completadas,{r.TransmisionesCompletadas}");
            sb.AppendLine($"Tiempo (ms),{r.TiempoMs}");
            sb.AppendLine($"Throughput (trx/seg),{r.ThroughputTrxSeg.ToString(CultureInfo.InvariantCulture)}");
            sb.AppendLine($"Latencia min (ms),{r.LatenciaMinMs}");
            sb.AppendLine($"Latencia max (ms),{r.LatenciaMaxMs}");
            sb.AppendLine($"Latencia prom (ms),{r.LatenciaPromMs}");
            sb.AppendLine($"Latencia p50 (ms),{r.LatenciaP50Ms}");
            sb.AppendLine($"Latencia p90 (ms),{r.LatenciaP90Ms}");
            sb.AppendLine($"Latencia p95 (ms),{r.LatenciaP95Ms}");
            sb.AppendLine($"Latencia p99 (ms),{r.LatenciaP99Ms}");
            sb.AppendLine($"Throughput por hilo (trx/seg),{r.ThroughputPorHilo.ToString(CultureInfo.InvariantCulture)}");
            sb.AppendLine($"Tasa éxito hilos (%),{r.TasaExitoHilos.ToString(CultureInfo.InvariantCulture)}");
            sb.AppendLine($"Estabilidad latencia,{r.EstabilidadLatencia.ToString(CultureInfo.InvariantCulture)}");
            sb.AppendLine($"Tasa éxito transacciones (%),{r.TasaExitoTransacciones.ToString(CultureInfo.InvariantCulture)}");
            sb.AppendLine($"Consistencia rendimiento,{r.ConsistenciaRendimiento.ToString(CultureInfo.InvariantCulture)}");
            sb.AppendLine($"Correlation ID Base,{r.CorrelationIDBase}");
            File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
        }

        /// <summary>Exporta el reporte a un archivo JSON.</summary>
        public static void ExportarJson(LoadTestReport testReport, string path)
        {
            if (testReport == null) return;
            
            string json = JsonConvert.SerializeObject(testReport, JsonSettings);
            File.WriteAllText(path, json, Encoding.UTF8);
        }
    }
}
