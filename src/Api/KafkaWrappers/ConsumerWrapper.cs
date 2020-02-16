using System;
using System.Threading.Tasks;
using Api.KafkaWrappers.Interfaces;
using Confluent.Kafka;

namespace Api.KafkaWrappers
{
    public class ConsumerWrapper : IConsumerWrapper
    {
        private readonly IConsumer<string, string> consumer;
        private bool subscribed { get; set; }

        public ConsumerWrapper(
            ConsumerConfig consumerConfig)
        {
            consumer = new ConsumerBuilder<string, string>(consumerConfig).Build();
        }

        public string ReadMessage()
        {
            if (!subscribed)
            {
                throw new Exception("Must subscribe to a topic before attempting to consume");
            }

            var result = consumer.Consume();

            if (result.Message == null)
            {
                return string.Empty;
            }

            return result.Value;
        }

        public void Subscribe(string topic)
        {
            consumer.Subscribe(topic);
            subscribed = true;
        }
    }
}