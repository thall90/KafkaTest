using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Api.KafkaWrappers.Interfaces;
using Api.Models;
using Api.Utilities.Interfaces;
using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IProducerWrapper producer;
        private readonly IJsonDataSerializer serializer;

        public OrderController(
            IProducerWrapper producer,
            IJsonDataSerializer serializer)
        {
            this.producer = producer;
            this.serializer = serializer;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(
            [FromBody] OrderRequest request,
            CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var serializedOrderRequest = serializer.SerializeObject(request);

            await producer.WriteMessage(Topics.OrderRequests, serializedOrderRequest, cancellationToken);

            return Created("TransactionId", "Your order is in progress!");
        }
    }
}
