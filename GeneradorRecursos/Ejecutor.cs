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
                Generar generador = new Generar(Ruta);
                generador.CrearRecursos();
                Console.WriteLine("Terminando de generar...");
            }

            if (GenerarConstantes)
            {
                Console.WriteLine("Generando Constantes");
                GenerarConstantes generador = new GenerarConstantes(Ruta);
                generador.CrearConstantes();
                Console.WriteLine("Terminando de generar...");
            }
        }
        
    }
}
