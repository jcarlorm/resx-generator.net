using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using System.IO;
using Microsoft.CSharp;
using System.CodeDom;
using System.Resources.Tools;
using System.CodeDom.Compiler;
using System.Configuration;
using Microsoft.VisualBasic;

namespace GeneradorRecursos
{
    public class Generar : Configuracion
    {
        public Generar(string ruta) : base(ruta) { }

        static Func<string, string> ObtieneNombreArchivoResx = cultura =>
        {
            return CulturaDefault == cultura ? $"{Ruta}{NombreArchivo}.resx" : $"{Ruta}{NombreArchivo}.{cultura}.resx" ;
        };

        static Action<List<Localizacion>,string> CreaResx = (recurso, nombreArchivo) => {
            using (ResXResourceWriter resx = new ResXResourceWriter(nombreArchivo))
            {
                recurso.ForEach(r =>
                {
                    resx.AddResource(r.Nombre, r.Mensaje);
                });
                resx.Generate();
            };

        };

        static Action CompiladorCS = () =>
        {
            StreamWriter sw = new StreamWriter($"{Ruta}{NombreArchivo}.cs");
            string[] errors = null;
            CSharpCodeProvider provider = new CSharpCodeProvider();
            CodeCompileUnit code = StronglyTypedResourceBuilder.Create($"{Ruta}{NombreArchivo}.resx", NombreArchivo,
                                                                       Namespace, provider,
                                                                       false, out errors);
            if (errors.Length > 0)
                foreach (var error in errors)
                    Console.WriteLine(error);

            provider.GenerateCodeFromCompileUnit(code, sw, new CodeGeneratorOptions());
            sw.Close();
        };

      
        static Action CompiladorVB = () =>
        {
            StreamWriter sw = new StreamWriter($"{Ruta}{NombreArchivo}.vb");
            string[] errors = null;
            VBCodeProvider provider = new VBCodeProvider();
            CodeCompileUnit code = StronglyTypedResourceBuilder.Create($"{Ruta}{NombreArchivo}.resx", NombreArchivo,
                                                                       Namespace, provider,
                                                                       true, out errors);
            if (errors.Length > 0)
                foreach (var error in errors)
                    Console.WriteLine(error);

            provider.GenerateCodeFromCompileUnit(code, sw, new CodeGeneratorOptions());
            sw.Close();
        };

        public void CrearRecursos()
        {

            Culturas.ForEach(cultura => {

                var Recursos = from res in db.Localizacion
                               where res.Cultura == cultura
                               select res;
                CreaResx(Recursos.ToList(), ObtieneNombreArchivoResx(cultura));
            });


            switch (Compilador)
            {
                case "cs":
                    CompiladorCS();
                    break;
                case "vb":
                    //CompiladorVB();
                    break;
                default:
                    Console.WriteLine($"No posee compilador para: {Compilador}");
                    break;
            }
        }
    }
}
