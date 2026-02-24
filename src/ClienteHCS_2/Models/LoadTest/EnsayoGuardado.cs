using System.Collections.Generic;

namespace ClienteHCS_2
{
    internal sealed class EnsayoGuardado
    {
        public LoadTestReport Reporte { get; set; }
        public List<LoadTestThreadItem> Hilos { get; set; }
        public LoadTestDefinition Definicion { get; set; }
    }
}
