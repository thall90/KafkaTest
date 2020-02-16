using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Api.KafkaWrappers.Interfaces;
using Confluent.Kafka;
using Microsoft.Extensions.Logging;

namespace Api.KafkaWrappers
{
    public class ProducerWrapper : IProducerWrapper
    {
        private readonly ILogger<ProducerWrapper> logger;
        private readonly IProducer<string, string> producer;

        public ProducerWrapper(
            ProducerConfig producerConfig,
            ILogger<ProducerWrapper> logger)
        {
            this.logger = logger;
            producer = new ProducerBuilder<string, string>(producerConfig).Build();
        }

        public async Task WriteMessage(
            string topicName,
            string message,
            CancellationToken cancellationToken)
        {
            var duh = await producer.ProduceAsync(topicName, new Message<string, string>
            {
                Key = new Random().Next(5).ToString(), // Guid.NewGuid().ToString(),
                Value = message
            });

            logger.LogInformation($"KAFKA => Delivered {duh.Value} to {duh.TopicPartitionOffset}");
        }

        public void Flush()
        {
            producer.Flush();
        }
    }
}