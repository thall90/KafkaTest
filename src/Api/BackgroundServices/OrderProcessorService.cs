using System;
using System.Threading;
using System.Threading.Tasks;
using Api.KafkaWrappers.Interfaces;
using Api.Models;
using Api.Models.Enums;
using Api.Utilities.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Api.BackgroundServices
{
    public class OrderProcessorService : BackgroundService
    {
        // private readonly IServiceProvider serviceProvider;
        // private readonly IJsonDataSerializer serializer;
        // private readonly ILogger<OrderProcessorService> logger;
        //
        // public OrderProcessorService(
        //     IServiceProvider serviceProvider,
        //     IJsonDataSerializer serializer,
        //     ILogger<OrderProcessorService> logger)
        // {
        //     this.serviceProvider = serviceProvider;
        //     this.serializer = serializer;
        //     this.logger = logger;
        // }

        public OrderProcessorService()
        {
        }

        protected override async Task ExecuteAsync(
            CancellationToken stoppingToken)
        {
            // logger.LogInformation("Order Processor Service Started!");

            while (!stoppingToken.IsCancellationRequested)
            {
                // using var scope = serviceProvider.CreateScope();
                // var consumer = scope.ServiceProvider.GetRequiredService<IConsumerWrapper>();
                // var producer = scope.ServiceProvider.GetRequiredService<IProducerWrapper>();
                //
                // consumer.Subscribe(Topics.OrderRequests);
                //
                // var message = consumer.ReadMessage();
                //
                // if (string.IsNullOrEmpty(message))
                // {
                //     continue;
                // }
                //
                // var order = serializer.DeserializeObject<OrderRequest>(message);
                //
                // logger.LogInformation($"Info: OrderHandler => Processing the order for {order.ProductName}");
                //
                // order.Status = OrderStatus.Completed;
                //
                // await producer.WriteMessage(
                //     Topics.ReadyToShip,
                //     serializer.SerializeObject(order),
                //     stoppingToken);
                //
                // producer.Flush();
            }
        }
    }
}