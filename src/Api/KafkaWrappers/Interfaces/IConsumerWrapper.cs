using System.Threading.Tasks;

namespace Api.KafkaWrappers.Interfaces
{
    public interface IConsumerWrapper
    {
        string ReadMessage();

        void Subscribe(string topic);
    }
}