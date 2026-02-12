using System;
using System.Collections.Generic;
using System.Linq;

namespace ClienteHCS_2.Helpers
{
    /// <summary>
    /// Funciones de cálculo estadístico usadas en reportes de prueba de carga.
    /// </summary>
    public static class StatisticsHelper
    {
        /// <summary>Escala por defecto (ms) para que la estabilidad quede en rango 0-1.</summary>
        public const double K_ESTABILIDAD_MS_DEFAULT = 100.0;

        /// <summary>Desvío estándar muestral de una secuencia de valores.</summary>
        public static double DesvioEstandar(IEnumerable<double> valores)
        {
            var list = valores.ToList();
            if (list.Count < 2) return 0;
            double media = list.Average();
            double sumSq = list.Sum(x => (x - media) * (x - media));
            return Math.Sqrt(sumSq / (list.Count - 1));
        }

        /// <summary>Percentil interpolado de un array ya ordenado (0-100).</summary>
        public static long Percentil(long[] sorted, double percentil)
        {
            if (sorted == null || sorted.Length == 0) return 0;
            double index = (percentil / 100.0) * (sorted.Length - 1);
            int i = (int)Math.Floor(index);
            if (i >= sorted.Length - 1) return sorted[sorted.Length - 1];
            double frac = index - i;
            return (long)(sorted[i] * (1 - frac) + sorted[i + 1] * frac);
        }

        /// <summary>Estabilidad de latencia: 1 / (1 + σ/k). Valores en [0, 1]; mayor = más estable.</summary>
        /// <param name="sigma">Desvío estándar (ej. en ms).</param>
        /// <param name="kMs">Escala en las mismas unidades que sigma (por defecto 100).</param>
        public static double EstabilidadLatencia(double sigma, double kMs = K_ESTABILIDAD_MS_DEFAULT)
        {
            return 1.0 / (1.0 + sigma / kMs);
        }
    }
}
