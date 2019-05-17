using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Dynamic;
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
            dynamic constante = new ExpandoObject();

            var constantes = from con in db.Constantes
                             select con;
            constantes.ToList().ForEach(c => {
                AddProperty(constante, c.Nombre, c.Valor);
            });

            var root = new
            {
                Constantes = constante
            };

            string JSON = JsonConvert.SerializeObject(root);

            
            StreamWriter sw = new StreamWriter($"{Ruta}{ClaseConstantes}.json");
            sw.Write(JSON);
            sw.Close();

        }

        public static void AddProperty(ExpandoObject expando, string propertyName, object propertyValue)
        {
            // ExpandoObject supports IDictionary so we can extend it like this
            var expandoDict = expando as IDictionary<string, object>;
            if (expandoDict.ContainsKey(propertyName))
                expandoDict[propertyName] = propertyValue;
            else
                expandoDict.Add(propertyName, propertyValue);
        }
    }


}
