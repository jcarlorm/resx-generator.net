using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GeneradorRecursos
{
    public class GenerarJSON : Configuracion
    {
        public GenerarJSON (string ruta) : base(ruta) { }

        public void CrearJSONConstantes()
        {
            Type constante = Type.GetType($"{Namespace}.{ClaseConstantes}");

            var constantes = Activator.CreateInstance(constante);

            var root = new {
                Constantes = constantes
            };
            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = new StaticPropertyContractResolver();

            string JSON = JsonConvert.SerializeObject(constante, serializerSettings);
            var baseMembers = constante.GetMembers();

            Type type = Type.GetType($"{Namespace}.{ClaseConstantes}"); 
            foreach (var p in type.GetProperties())
            {
                var v = p.GetValue(null, null); // static classes cannot be instanced, so use null...
            }
            PropertyInfo[] staticMembers =
                constante.GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);

            StreamWriter sw = new StreamWriter($"{Ruta}{ClaseConstantes}.json");
            sw.Write(JSON);
            sw.Close();

        }
    }


    public class StaticPropertyContractResolver : DefaultContractResolver
    {
        protected override List<MemberInfo> GetSerializableMembers(Type objectType)
        {
            var baseMembers = base.GetSerializableMembers(objectType);

            PropertyInfo[] staticMembers =
                objectType.GetProperties(BindingFlags.Static | BindingFlags.Public);

            baseMembers.AddRange(staticMembers);

            return baseMembers;
        }
    }
}
