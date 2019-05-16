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

        public GenerarConstantes(string ruta) : base(ruta) { }

        public void CrearConstantes()
        {
            CodeCompileUnit compileUnit = new CodeCompileUnit();

            CodeNamespace targetNamespace = new CodeNamespace(Namespace);

            CodeTypeDeclaration targetClass = new CodeTypeDeclaration(ClaseConstantes);
            targetClass.IsClass = true;
            targetClass.TypeAttributes = System.Reflection.TypeAttributes.Public;
            targetNamespace.Types.Add(targetClass);

            CodeMemberField testField = new CodeMemberField();
            testField.Name = "Prueba";
            testField.Type = new CodeTypeReference(typeof(string));
            testField.Attributes = MemberAttributes.Public | MemberAttributes.Static;
            testField.InitExpression = new CodeFieldReferenceExpression(new CodeTypeReferenceExpression("string"), "Hola");
            targetClass.Members.Add(testField);

            compileUnit.Namespaces.Add(targetNamespace);
            StreamWriter sw = new StreamWriter($"{Ruta}{ClaseConstantes}.cs");
            CSharpCodeProvider provider = new CSharpCodeProvider();
            provider.GenerateCodeFromCompileUnit(compileUnit, sw, new CodeGeneratorOptions());
            sw.Close();
        }


    }
}
