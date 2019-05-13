using System;
using System.Configuration;

namespace GeneradorRecursos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Generando Recursos");
            Generar generador = new Generar(ConfigurationManager.AppSettings["RutaDestino"].ToString());
            generador.CrearRecursos();
            Console.WriteLine("Terminando de generar...");

        }
    }
}
