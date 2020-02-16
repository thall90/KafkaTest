using System.Threading;
using System.Threading.Tasks;

namespace Api.KafkaWrappers.Interfaces
{
    public interface IProducerWrapper
    {
        Task WriteMessage(string topicName, string message, CancellationToken cancellationToken);

        void Flush();
    }
}