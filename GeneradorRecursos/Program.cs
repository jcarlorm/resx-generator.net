using System;
using System.Configuration;

namespace GeneradorRecursos
{
    class Program
    {
        static void Main(string[] args)
        {
            Ejecutor ejecutarTareas = new Ejecutor(ConfigurationManager.AppSettings["RutaDestino"].ToString());
            ejecutarTareas.GenerarCodigo();

        }
    }
}
