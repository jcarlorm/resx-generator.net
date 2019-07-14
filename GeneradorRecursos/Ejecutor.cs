using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneradorRecursos
{
    public class Ejecutor : Configuracion
    {
        public Ejecutor(string ruta) : base(ruta) { } 

        public void GenerarCodigo()
        {
            if (GenerarRecursos)
            {
                Console.WriteLine("Generando Recursos");
                new Generar(Ruta).CrearRecursos();
                Console.WriteLine("Terminando de generar...");
            }

            if (GenerarConstantes)
            {
                Console.WriteLine("Generando Constantes");
                new GenerarConstantes(Ruta).CrearConstantes();
                Console.WriteLine("Terminando de generar...");
            }

            if (GenerarConstantesJSON)
            {
                new GenerarJSON(Ruta).CrearJSONConstantes();
            }
        }
        
    }
}
