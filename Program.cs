// Código documentado por Luis R Collymoore con la ayuda de una inteligencia artificial.
// El código escrito pertenece y fue creado por Luis R Collymoore.

using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        string output = ""; // Variable para almacenar la salida de los comandos de winget

        while (true)
        {
            Console.WriteLine("App CLI by @collym");
            Console.WriteLine();
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("1. Ver los paquetes disponibles para descarga");
            Console.WriteLine("2. Instalar paquetes");
            Console.WriteLine("3. Eliminar paquetes");
            Console.WriteLine("4. Github");
            Console.WriteLine("5. Actualizar todos los paquetes");
            Console.WriteLine("6. Salir");

            string? opt = Console.ReadLine(); // Opción seleccionada por el usuario

            switch (opt)
            {
                case "1":
                    output = ExecuteWingetCommand("search id"); // Ejecutar comando "winget search id"
                    Console.WriteLine(output); // Imprimir la salida del comando
                    Console.WriteLine();
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;
                case "2":
                    Console.WriteLine("Ingrese el Nombre del paquete");
                    string? packageName = Console.ReadLine(); // Nombre del paquete ingresado por el usuario
                    output = ExecuteWingetCommand($"search {packageName}"); // Ejecutar comando "winget search {packageName}"
                    if (string.IsNullOrWhiteSpace(packageName))
                    {
                        Console.WriteLine("El paquete no puede estar vacío. Por favor, intente nuevamente.");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine(output); // Imprimir la salida del comando
                        Console.WriteLine();
                    }
                    if (output.Contains("No package found matching input criteria."))
                    {
                        Console.WriteLine($"El paquete '{packageName}' no se encontró o no existe.");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Ingrese el Id del paquete para descargar");
                        string? packageId = Console.ReadLine(); // Id del paquete ingresado por el usuario
                        if (string.IsNullOrWhiteSpace(packageId))
                        {
                            Console.WriteLine("El Id del paquete no puede estar vacío. Por favor, intente nuevamente.");
                            Console.WriteLine();
                        }
                        else
                        {
                            output = ExecuteWingetCommand($"Install {packageId}"); // Ejecutar comando "winget install {packageId}"
                            Console.WriteLine(output); // Imprimir la salida del comando
                            Console.WriteLine();
                        }
                    }
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;
                case "3":
                    Console.WriteLine("Ingrese el Nombre del paquete");
                    string? package = Console.ReadLine(); // Nombre del paquete ingresado por el usuario
                    output = ExecuteWingetCommand($"search {package}"); // Ejecutar comando "winget search {package}"
                    if (string.IsNullOrWhiteSpace(package))
                    {
                        Console.WriteLine("El paquete no puede estar vacío. Por favor, intente nuevamente.");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine(output); // Imprimir la salida del comando
                        Console.WriteLine();
                    }
                    if (output.Contains("No package found matching input criteria."))
                    {
                        Console.WriteLine($"El paquete '{package}' no se encontró o no existe.");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Ingrese el Id del paquete para descargar");
                        string? packageId = Console.ReadLine(); // Id del paquete ingresado por el usuario
                        if (string.IsNullOrWhiteSpace(packageId))
                        {
                            Console.WriteLine("El Id del paquete no puede estar vacío. Por favor, intente nuevamente.");
                            Console.WriteLine();
                        }
                        else
                        {
                            output = ExecuteWingetCommand($"Uninstall {packageId}"); // Ejecutar comando "winget uninstall {packageId}"
                            Console.WriteLine(output); // Imprimir la salida del comando
                            Console.WriteLine();
                        }
                    }
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;
                case "4":
                    string url = "https://github.com/collym97?tab=repositories"; // URL del repositorio de GitHub
                    OpenUrl(url); // Abrir la URL en el navegador predeterminado
                    Console.WriteLine();
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;
                case "5":
                    output = ExecuteWingetCommand("upgrade"); // Ejecutar comando "winget upgrade" para actualizar todos los paquetes
                    Console.WriteLine(output); // Imprimir la salida del comando
                    Console.WriteLine();
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;
                case "6":
                    Console.WriteLine("¡Hasta luego!"); // Salir del programa
                    return;
                default:
                    Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                    Console.WriteLine();
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;
            }

            Console.Clear(); // Limpiar la consola antes de mostrar el siguiente menú
        }
    }

    static string ExecuteWingetCommand(string command)
    {
        ProcessStartInfo processInfo = new ProcessStartInfo
        {
            FileName = "winget",
            Arguments = command,
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using (Process process = new Process())
        {
            process.StartInfo = processInfo;
            process.Start();
            string output = process.StandardOutput.ReadToEnd(); // Obtener la salida del proceso
            process.WaitForExit();
            return output; // Devolver la salida del proceso
        }
    }

    static void OpenUrl(string url)
    {
        try
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "cmd",
                Arguments = $"/c start {url}",
                UseShellExecute = false,
                CreateNoWindow = true
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine("No se pudo abrir la URL: " + ex.Message);
        }
    }
}
