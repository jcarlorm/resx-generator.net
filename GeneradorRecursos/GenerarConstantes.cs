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

namespace GeneradorRecursos
{
    public class GenerarConstantes : Configuracion
    {
        protected static CodeCompileUnit compileUnit = new CodeCompileUnit();
        protected static CodeNamespace targetNamespace = new CodeNamespace(Namespace);
        protected static CodeTypeDeclaration targetClass = new CodeTypeDeclaration(ClaseConstantes);

        public GenerarConstantes(string ruta) : base(ruta) { }

        protected static Action<List<Constantes>> GenerarCampos = (constantes) => {

            constantes.ForEach(constante => {

                CodeMemberField campoConstante = new CodeMemberField();
                campoConstante.Name = constante.Nombre;
                campoConstante.Type = new CodeTypeReference(Type.GetType(constante.Tipo));
                campoConstante.Attributes = MemberAttributes.Public | MemberAttributes.Static;
                campoConstante.InitExpression = new CodePrimitiveExpression(convertirValorConstante(constante.Tipo, constante.Valor));
                targetClass.Members.Add(campoConstante);
            });
        };

        protected static Func<string, string, object> convertirValorConstante = (tipo, valor) => {

            switch (tipo)
            {
                case "System.Boolean":
                    return Boolean.Parse(valor) ? true : false;
                default:
                    return valor.ToString();
            }
        };

        public void CrearConstantes()
        {
            targetClass.IsClass = true;
            targetClass.TypeAttributes = System.Reflection.TypeAttributes.Public;
            targetNamespace.Types.Add(targetClass);

            var constantes = from constante in db.Constantes
                             select constante;

            GenerarCampos(constantes.ToList());

            compileUnit.Namespaces.Add(targetNamespace);
            StreamWriter sw = new StreamWriter($"{Ruta}{ClaseConstantes}.cs");
            CSharpCodeProvider provider = new CSharpCodeProvider();
            provider.GenerateCodeFromCompileUnit(compileUnit, sw, new CodeGeneratorOptions());
            sw.Close();
        }


    }
}
