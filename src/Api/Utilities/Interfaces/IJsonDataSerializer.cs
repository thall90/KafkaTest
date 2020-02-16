namespace Api.Utilities.Interfaces
{
    public interface IJsonDataSerializer
    {
        string SerializeObject(object objectToSerialize);

        T DeserializeObject<T>(string objectToDeserialize);
    }
}