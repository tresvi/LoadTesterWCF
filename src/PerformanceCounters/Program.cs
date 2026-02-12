using System;
using System.Diagnostics;
using System.Threading;

namespace PerformanceCounters
{
    class Program
    {

        private static PerformanceCounter CurrentRequests, AvgResponse, RateOfRequests, RateOfProcess,
                                              RateOfPuts, RateOfGets,
                                              GetFailures, PutFailures, ConexionFailures;

        static void Main()
        {
            //Crear los contadores de performance.
            try
            {
                CurrentRequests = new PerformanceCounter(CounterDefs.PERFORMANCE_COUNTER_CATEGORY_NAME, CounterDefs.CURRENT_REQUESTS_NAME, true);
                AvgResponse = new PerformanceCounter(CounterDefs.PERFORMANCE_COUNTER_CATEGORY_NAME, CounterDefs.AVG_RESPONSE_TIME_NAME, true);
                RateOfRequests = new PerformanceCounter(CounterDefs.PERFORMANCE_COUNTER_CATEGORY_NAME, CounterDefs.RATE_OF_REQUESTS_NAME, true);
                RateOfProcess = new PerformanceCounter(CounterDefs.PERFORMANCE_COUNTER_CATEGORY_NAME, CounterDefs.RATE_OF_PROCESSED_NAME, true);
                RateOfPuts = new PerformanceCounter(CounterDefs.PERFORMANCE_COUNTER_CATEGORY_NAME, CounterDefs.RATE_OF_SENT_MSGS_NAME, true);
                RateOfGets = new PerformanceCounter(CounterDefs.PERFORMANCE_COUNTER_CATEGORY_NAME, CounterDefs.RATE_OF_RECEVIED_MSGS_NAME, true);
                GetFailures = new PerformanceCounter(CounterDefs.PERFORMANCE_COUNTER_CATEGORY_NAME, CounterDefs.GET_FAILURES_NAME, true);
                PutFailures = new PerformanceCounter(CounterDefs.PERFORMANCE_COUNTER_CATEGORY_NAME, CounterDefs.PUT_FAILURES_NAME, true);
                ConexionFailures = new PerformanceCounter(CounterDefs.PERFORMANCE_COUNTER_CATEGORY_NAME, CounterDefs.CONNECTION_FAILURES_NAME, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR al crear los contadores. Detalles: {ex.Message}");
            }

            // Crear el objeto PerformanceCounter
            // PerformanceCounter performanceCounter = new PerformanceCounter(categoryName, counterName, readOnly: true, );
            //PerformanceCounter performanceCounter = new PerformanceCounter(categoryName, counterName,  "remoteMachineName");

            try
            {
                while (true)
                {
                    // Leer el valor actual del contador
                    //float value = performanceCounter.NextValue();

                    // Imprimir el valor
                    //Console.WriteLine($"Valor actual del contador: {value}");
                    Console.Clear();
                    Console.SetCursorPosition(0, Console.CursorTop);

                    Console.WriteLine($"{CurrentRequests.CounterName}: {CurrentRequests.NextValue()}");
                    Console.WriteLine($"{AvgResponse.CounterName}: {AvgResponse.NextValue()}");
                    Console.WriteLine($"{RateOfRequests.CounterName}: {RateOfRequests.NextValue()}");
                    Console.WriteLine($"{RateOfProcess.CounterName}: {RateOfProcess.NextValue()}");
                    Console.WriteLine($"{RateOfPuts.CounterName}: {RateOfPuts.NextValue()}");
                    Console.WriteLine($"{RateOfGets.CounterName}: {RateOfGets.NextValue()}");
                    Console.WriteLine($"{GetFailures.CounterName}: {GetFailures.NextValue()}");
                    Console.WriteLine($"{PutFailures.CounterName}: {PutFailures.NextValue()}");
                    Console.WriteLine($"{ConexionFailures.CounterName}: {ConexionFailures.NextValue()}");

                    Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer el contador de rendimiento: {ex.Message}");
            }
            finally
            {
                CurrentRequests.Dispose();
                AvgResponse.Dispose();
                RateOfRequests.Dispose();
                RateOfProcess.Dispose();
                RateOfPuts.Dispose();
                RateOfGets.Dispose();
                GetFailures.Dispose();
                PutFailures.Dispose();
                ConexionFailures.Dispose();
            }
        }
    }
}
