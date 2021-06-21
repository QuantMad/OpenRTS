namespace Databases
{
    public interface IDeserializable
    {
        void DeserializeProperties(string json);
        string SerializeProperties();
    }
}
