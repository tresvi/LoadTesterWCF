# Cliente_HCS
Herramienta para diagnosticar HCS

## Métricas de Pruebas de Carga

Este documento explica todas las métricas que se calculan y registran durante las pruebas de carga del sistema HCS.

### Métricas Básicas del Ensayo

#### **Total Hilos**
- **Descripción**: Número total de hilos (threads) configurados para ejecutarse en paralelo durante la prueba.
- **Unidad**: Cantidad (adimensional)
- **Interpretación**: Indica el nivel de concurrencia de la prueba.

#### **Pausa entre transmisiones (ms)**
- **Descripción**: Tiempo de espera configurado entre cada transmisión dentro de un mismo hilo.
- **Unidad**: Milisegundos (ms)
- **Interpretación**: Controla la velocidad de envío de transacciones por hilo. Un valor de 0 significa sin pausa.

#### **Tiempo (ms)**
- **Descripción**: Duración total del ensayo desde el inicio hasta la finalización.
- **Unidad**: Milisegundos (ms)
- **Interpretación**: Tiempo real que tomó completar la prueba de carga.

---

### Métricas de Finalización de Hilos

#### **Finalizados OK**
- **Descripción**: Cantidad de hilos que completaron su ejecución exitosamente sin errores.
- **Unidad**: Cantidad (adimensional)
- **Interpretación**: Mayor valor indica mejor estabilidad del sistema bajo carga.

#### **Finalizados FAIL**
- **Descripción**: Cantidad de hilos que terminaron con errores o excepciones durante su ejecución.
- **Unidad**: Cantidad (adimensional)
- **Interpretación**: Indica problemas de estabilidad o capacidad del sistema.

---

### Métricas de Transmisiones

#### **Transmisiones Completadas**
- **Descripción**: Número total de transacciones que recibieron respuesta exitosa del servidor.
- **Unidad**: Cantidad (adimensional)
- **Interpretación**: Mide la capacidad del sistema para procesar y responder transacciones.

#### **Transmisiones Sin Respuesta**
- **Descripción**: Número de transacciones que no recibieron respuesta (errores, timeouts, excepciones).
- **Unidad**: Cantidad (adimensional)
- **Interpretación**: Indica problemas de conectividad, timeouts o errores del servidor.

---

### Métricas de Rendimiento (Throughput)

#### **Throughput (trx/seg)**
- **Descripción**: Número total de transacciones procesadas por segundo en todo el ensayo.
- **Cálculo**: `TransmisionesCompletadas / TiempoTotalSegundos`
- **Unidad**: Transacciones por segundo (trx/seg)
- **Interpretación**: Mide la capacidad global del sistema. Valores más altos indican mejor rendimiento.

#### **Throughput por Hilo**
- **Descripción**: Throughput promedio por cada hilo que finalizó exitosamente.
- **Cálculo**: `ThroughputTotal / HilosFinalizadosOK`
- **Unidad**: Transacciones por segundo (trx/seg)
- **Interpretación**: Indica el rendimiento individual de cada hilo. Útil para detectar desbalances.

---

### Métricas de Latencia

#### **Latencia Mínima (ms)**
- **Descripción**: Tiempo de respuesta más corto registrado durante la prueba.
- **Unidad**: Milisegundos (ms)
- **Interpretación**: Representa el mejor caso de respuesta del sistema.

#### **Latencia Máxima (ms)**
- **Descripción**: Tiempo de respuesta más largo registrado durante la prueba.
- **Unidad**: Milisegundos (ms)
- **Interpretación**: Indica el peor caso de respuesta. Valores muy altos pueden indicar problemas de rendimiento.

#### **Latencia Promedio (ms)**
- **Descripción**: Media aritmética de todos los tiempos de respuesta exitosos.
- **Cálculo**: `Suma(Latencias) / CantidadTransmisiones`
- **Unidad**: Milisegundos (ms)
- **Interpretación**: Tiempo de respuesta típico del sistema. Útil para comparaciones generales.

#### **Percentiles de Latencia (p50, p90, p95, p99)**
- **Descripción**: Valores que indican que un porcentaje específico de las respuestas fueron más rápidas que ese valor.
  - **p50 (Mediana)**: 50% de las respuestas fueron más rápidas
  - **p90**: 90% de las respuestas fueron más rápidas
  - **p95**: 95% de las respuestas fueron más rápidas
  - **p99**: 99% de las respuestas fueron más rápidas
- **Unidad**: Milisegundos (ms)
- **Interpretación**: 
  - **p50**: Representa el caso típico (mediana)
  - **p90-p99**: Identifican outliers y problemas de rendimiento. Valores altos en estos percentiles indican que algunas transacciones tienen latencias excepcionalmente altas.

---

### Métricas de Calidad del Ensayo

#### **Tasa de Éxito de Hilos (%)**
- **Descripción**: Porcentaje de hilos que finalizaron exitosamente.
- **Cálculo**: `(FinalizadosOK / TotalHilos) * 100`
- **Unidad**: Porcentaje (0-100%)
- **Interpretación**: 
  - **100%**: Todos los hilos completaron correctamente (ideal)
  - **< 100%**: Algunos hilos fallaron, indicando problemas de estabilidad o capacidad
- **Rango**: 0% a 100%

#### **Tasa de Éxito de Transacciones (%)**
- **Descripción**: Porcentaje de transacciones que se completaron exitosamente (recibieron respuesta del servidor).
- **Cálculo**: `(TransmisionesCompletadas / TotalTransmisiones) * 100`
- **Unidad**: Porcentaje (0-100%)
- **Interpretación**: 
  - **100%**: Todas las transacciones fueron exitosas (ideal)
  - **< 100%**: Algunas transacciones fallaron (errores, timeouts)
- **Rango**: 0% a 100%
- **Nota**: Esta métrica mide la confiabilidad a nivel de transacción individual, complementando la tasa de éxito de hilos.

#### **Estabilidad de Latencia**
- **Descripción**: Índice que mide qué tan consistentes son las latencias entre diferentes hilos.
- **Cálculo**: `1 / (1 + σ/k)`, donde:
  - `σ` = desviación estándar de las latencias promedio por hilo
  - `k` = constante de escala (por defecto 100 ms)
- **Unidad**: Adimensional (0-1)
- **Interpretación**: 
  - **Valores cercanos a 1.0**: Latencias muy consistentes entre hilos (ideal)
  - **Valores cercanos a 0.0**: Latencias muy variables entre hilos (problemas de balanceo o recursos)
- **Rango**: 0.0 a 1.0
- **Ejemplo**: Si todos los hilos tienen latencias similares, la desviación estándar es baja y la estabilidad es alta.

#### **Consistencia de Rendimiento**
- **Descripción**: Índice que mide qué tan uniforme es el throughput entre diferentes hilos.
- **Cálculo**: `1 / (1 + CV)`, donde:
  - `CV` = Coeficiente de Variación = `σ / μ`
  - `σ` = desviación estándar del throughput por hilo
  - `μ` = promedio del throughput por hilo
- **Unidad**: Adimensional (0-1)
- **Interpretación**: 
  - **Valores cercanos a 1.0**: Throughput muy uniforme entre hilos (ideal)
  - **Valores cercanos a 0.0**: Throughput muy desigual entre hilos (cuellos de botella, desbalanceo)
- **Rango**: 0.0 a 1.0
- **Ejemplo práctico**:
  - **Alta consistencia**: Hilos con throughput [9, 10, 11] trx/seg → CV bajo → Consistencia ≈ 0.92
  - **Baja consistencia**: Hilos con throughput [2, 10, 18] trx/seg → CV alto → Consistencia ≈ 0.60
- **Nota**: Esta métrica complementa la estabilidad de latencia, midiendo la uniformidad del rendimiento en lugar de la uniformidad de los tiempos de respuesta.

---

### Resumen de Interpretación de Métricas

#### **Métricas de Rendimiento (más alto = mejor)**
- Throughput (trx/seg)
- Throughput por Hilo
- Tasa de Éxito de Hilos (%)
- Tasa de Éxito de Transacciones (%)
- Estabilidad de Latencia
- Consistencia de Rendimiento

#### **Métricas de Latencia (más bajo = mejor)**
- Latencia Mínima, Máxima, Promedio
- Percentiles (p50, p90, p95, p99)

#### **Métricas de Problemas (más bajo = mejor)**
- Finalizados FAIL
- Transmisiones Sin Respuesta

---

### Exportación de Métricas

Todas las métricas se pueden exportar en dos formatos:

1. **CSV**: Formato de valores separados por comas, ideal para análisis en Excel o herramientas de análisis de datos.
2. **JSON**: Formato estructurado, ideal para integración con otras aplicaciones o análisis programático.

Las métricas exportadas incluyen todos los valores mencionados anteriormente, permitiendo análisis detallados y comparaciones entre diferentes ejecuciones de pruebas.


Agregar carga de ensayo
hacer barra con comandos
Implementar funcionalidad de comparacion. Como consideras que desde el punto de vista de experiencia de usuario se podria implementar una funcion de comparación de ensayos. Es decir, el usuario puede comparar el ensayo actual contra otro (abierto actualmente mas otro cuyo json se elija), y ver un gráfico de radar con la comparacion entre ellos

Ordenar en carpetas los formularios

Realizar warmup de 10 transacciones al iniciar ensayo. Que sea opcional con un numeric updown. Por default dejarlo en 5