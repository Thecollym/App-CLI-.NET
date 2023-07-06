// See https://aka.ms/new-console-template for more information
using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Console.WriteLine("Ingrese el nombre del paquete ");
        string? packageName = Console.ReadLine();

        // Ejecutar el proceso de Winget
        ProcessStartInfo processInfo = new ProcessStartInfo
        {
            FileName = "winget",
            Arguments = $"install {packageName}",
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        Process process = new Process();
        process.StartInfo = processInfo;
        process.Start();

       
        string output = process.StandardOutput.ReadToEnd();
        process.WaitForExit();

        
        Console.WriteLine(output);
    }
}

