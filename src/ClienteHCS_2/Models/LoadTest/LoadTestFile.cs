using System.Collections.Generic;

namespace ClienteHCS_2
{
    internal sealed class LoadTestFile
    {
        public const double FILE_VERSION = 1.0;

        public double Version { get; set; } = FILE_VERSION;
        public LoadTestReport Reporte { get; set; }
        public List<LoadTestThreadItem> Hilos { get; set; }
        public LoadTestDefinition Definicion { get; set; }
    }
}
