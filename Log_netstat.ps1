################### Configuracion ###################
$outputDir = "C:\Temp\NetstatOut"
$intervalInSeconds = 30
#####################################################


while ($true) {
    # Obtener la fecha y hora actual
    $dateTime = Get-Date
    $formattedDate = $dateTime.ToString("yyyy-MM-dd")
    $time = $dateTime.ToString("hh:mm:ss")

    # Obtener el PID del proceso HCSService.exe
    $processId = Get-Process -Name "HCSService" -ErrorAction SilentlyContinue | Select-Object -ExpandProperty Id

    if ($processId -ne $null) {
        # Construir el comando netstat con el PID
        $command = "netstat -noa | findstr $processId"

        # Ejecutar el comando netstat y contar las líneas
        $result = Invoke-Expression -Command $command
        $lineCount = ($result | Measure-Object -Line).Lines

        # Crear el nombre del archivo con la fecha
        $hcsOutputFile = "HCS_NetstatLog_$formattedDate.txt"
        $hcsOutputFilePath = Join-Path -Path $outputDir -ChildPath $hcsOutputFile

        # Crear la cadena de datos
        $data = "$time`t$lineCount"

        # Agregar la cadena al archivo
        Add-Content -Path $hcsOutputFilePath -Value $data
    }


    # Ejecutar el comando netstat y contar las líneas
    $result = netstat -noa
    $lineCount = ($result | Measure-Object -Line).Lines

    # Crear el nombre del archivo con la fecha
    $allProcessOutputFile = "AllProcess_NetstatLog_$formattedDate.txt"
    $allProcessOutputFilePath = Join-Path -Path $outputDir -ChildPath $allProcessOutputFile

    # Crear la cadena de datos
    $data = "$time`t$lineCount"

    # Agregar la cadena al archivo
    Add-Content -Path $allProcessOutputFilePath -Value $data

    # Esperar 30 segundos antes de la próxima ejecución
    Start-Sleep -Seconds $intervalInSeconds
}