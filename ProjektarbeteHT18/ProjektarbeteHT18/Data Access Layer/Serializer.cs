using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektarbeteHT18.Business_Logic_Layer
{
    public class Serializer<T>
    {
        private string Path { get; set; }
        private JsonSerializer JsonSerializer { get; set; }

        public Serializer(string pathToJsonFile)
        {
            Path = pathToJsonFile;
            JsonSerializer = new JsonSerializer
            {
                TypeNameHandling = TypeNameHandling.All
            };
        }

        public void Serialize(T obj)
        {

            using (var sw = new StreamWriter(Path))
            {
                using (var jtw = new JsonTextWriter(sw))
                {
                    JsonSerializer.Serialize(jtw, obj);
                }
            }
        }

        public T Deserialize()
        {
            using (var sr = new StreamReader(Path))
            {
                using (var jtr = new JsonTextReader(sr))
                {
                    return JsonSerializer.Deserialize<T>(jtr);
                }
            }
        }

    }
}
