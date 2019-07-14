using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneradorRecursos
{
    public class Configuracion
    {
        public RecursosEntities db = new RecursosEntities();

        public Configuracion(string ruta)
        {
            Ruta = ruta;
        }

        public static string Ruta { get; set; }
        public static string NombreArchivo => ConfigurationManager.AppSettings["NombreArchivo"].ToString();
        public static bool GenerarConstantes => Boolean.Parse(ConfigurationManager.AppSettings["GenerarConstantes"].ToString());
        public static bool GenerarConstantesJSON => Boolean.Parse(ConfigurationManager.AppSettings["GenerarConstantesJSON"].ToString());
        public static bool GenerarRecursos => Boolean.Parse(ConfigurationManager.AppSettings["GenerarRecursos"].ToString());
        public static string NombreArchivoConstantes => ConfigurationManager.AppSettings["NombreArchivoConstantes"].ToString();
        public static string CulturaDefault => ConfigurationManager.AppSettings["CulturaDefault"].ToString();
        public static string Compilador => ConfigurationManager.AppSettings["Compilador"].ToString();
        public static string Namespace => ConfigurationManager.AppSettings["Namespace"].ToString();
        public static string ClaseConstantes => ConfigurationManager.AppSettings["ClaseConstantes"].ToString();
        public static List<string> Culturas => ConfigurationManager.AppSettings["Culturas"].ToString().Split(new char[] { ',' }).ToList();

    }
}
