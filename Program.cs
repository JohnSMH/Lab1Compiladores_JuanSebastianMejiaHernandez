using System;
using LabCompiladores;
namespace ScannerBaseCompiladores
{
    class Program
    {
        static void Main(string[] args)
        {
            string entrada = Console.ReadLine();
            Parser parser = new Parser();
            double respuesta = parser.Parse(entrada);
            Console.WriteLine(respuesta);
            Console.WriteLine("Aceptada");
            Console.ReadKey();
        }
    }
}
