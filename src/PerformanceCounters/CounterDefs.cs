namespace PerformanceCounters
{
    class CounterDefs
    {
        //Contadores de eventos normales.
        public const string CURRENT_REQUESTS_NAME = "Requerimientos en Proceso";
        public const string CURRENT_REQUESTS_HELP = "Cantidad de requerimientos concurrentes.";
        public const string CURRENT_LISTENERS_NAME = "Servidores Aguardando";
        public const string CURRENT_LISTENERS_HELP = "Cantidad de instancias que se quedan escuchando";
        public const string RATE_OF_REQUESTS_NAME = "Requerimientos/s";
        public const string RATE_OF_REQUESTS_HELP = "Tasa de requerimientos/segundo que arriban";
        public const string RATE_OF_PROCESSED_NAME = "Procesamiento/s";
        public const string RATE_OF_PROCESSED_HELP = "Tasa de requerimientos/segundo que se procesan";
        public const string RATE_OF_SENT_MSGS_NAME = "Mensajes/s Enviados";
        public const string RATE_OF_SENT_MSGS_HELP = "Tasa de Mensajes/segundo que se envían.";
        public const string RATE_OF_RECEVIED_MSGS_NAME = "Mensajes/s Recibidos";
        public const string RATE_OF_RECEIVED_MSGS_HELP = "Tasa de Mensajes/segundo que se reciben.";
        public const string BASE_RESPONSE_TIME_NAME = "Base Promedio Respuesta";
        public const string BASE_RESPONSE_TIME_HELP = "Contador Base para el Tiempo Medio de Respuesta";
        public const string AVG_RESPONSE_TIME_NAME = "Promedio de Respuesta";
        public const string AVG_RESPONSE_TIME_HELP = "Tiempo promedio de respuesta.";

        //Contadores de eventos de fallas.
        public const string CONNECTION_FAILURES_NAME = "Fallas de Conexión";
        public const string CONNECTION_FAILURES_HELP = "Cantidad de conexiones que fallaron.";
        public const string GET_FAILURES_NAME = "Fallas de Get";
        public const string GET_FAILURES_HELP = "Cantidad de Get que no se pudieron hacer.";
        public const string PUT_FAILURES_NAME = "Fallas de Put";
        public const string PUT_FAILURES_HELP = "Cantidad de Put que no se pudieron hacer.";
        //Identificación general de los contadores de rendimiento.
        public const string PERFORMANCE_COUNTER_CATEGORY_NAME = "BNA.FU.MQConnector";
        public const string PERFORMANCE_COUNTER_CATEGORY_HELP = "Contadores de rendimiento del conector BNA.FU.MQConnector";

    }
}
