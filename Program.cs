using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("App CLI by @collym");
            Console.WriteLine();
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("1. Ver los paquetes disponibles para descarga");
            Console.WriteLine("2. Instalar paquetes");
            Console.WriteLine("3. Ver repositorio");
            Console.WriteLine("4. Salir");

            string? opt = Console.ReadLine();

            switch (opt)
            {
                case "1":
                    string output1 = ExecuteWingetCommand("search id");
                    Console.WriteLine(output1);
                    Console.WriteLine();
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;
                case "2":

                    Console.WriteLine("Ingrese el Nombre del paquete");
                    string? packageName = Console.ReadLine();
                    string output2 = ExecuteWingetCommand($"search {packageName}");
                    if (string.IsNullOrWhiteSpace(packageName))
                    {
                        Console.WriteLine("El  paquete no puede estar vacío. Por favor, intente nuevamente.");
                        Console.WriteLine();
                    }
                    else
                    {
                        
                        Console.WriteLine(output2);
                        Console.WriteLine();
                    }
                    if (output2.Contains("No package found matching input criteria."))
                    {
                        Console.WriteLine($"El paquete '{packageName}' no se encontró o no existe.");
                        Console.WriteLine();
                    }
                    else
                    {



                        Console.WriteLine("Ingrese el Id del paquete para descargar");
                        string? packageId = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(packageId))
                        {
                            Console.WriteLine("El Id del paquete no puede estar vacío. Por favor, intente nuevamente.");
                            Console.WriteLine();
                        }
                        else
                        {
                            string output3 = ExecuteWingetCommand($"Install {packageId}");
                            Console.WriteLine(output3);
                            Console.WriteLine();
                        }
                    }

                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;
                case "3":
                    string url = "https://github.com/collym97";
                    OpenUrl(url);
                    Console.WriteLine();
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;
                case "4":
                    Console.WriteLine("¡Hasta luego!");
                    return;
                default:
                    Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                    Console.WriteLine();
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;
            }

            Console.Clear();
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
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return output;
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
