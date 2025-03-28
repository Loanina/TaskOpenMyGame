using Newtonsoft.Json;

namespace App.Scripts.Modules.Serializer
{
    public class JsonConverter
    {
        public T Deserialize<T>(string text)
        {
            return JsonConvert.DeserializeObject<T>(text);
        }

        public string Serialize(object value)
        {
            return JsonConvert.SerializeObject(value);
        }
        
        
    }
}