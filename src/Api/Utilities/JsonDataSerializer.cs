using System.Text.Json;
using Api.Utilities.Interfaces;

namespace Api.Utilities
{
    public class JsonDataSerializer : IJsonDataSerializer
    {
        public string SerializeObject(object objectToSerialize)
        {
            return JsonSerializer.Serialize(objectToSerialize);
        }

        public T DeserializeObject<T>(string objectToDeserialize)
        {
            return JsonSerializer.Deserialize<T>(objectToDeserialize);
        }
    }
}