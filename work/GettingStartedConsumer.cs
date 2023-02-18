using System;
using MassTransit;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace work
{
    public class GettingStartedConsumer :
        IConsumer<GettingStarted>
    {
        readonly ILogger<GettingStartedConsumer> _logger;

        public GettingStartedConsumer(ILogger<GettingStartedConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<GettingStarted> context)
        {
            _logger.LogInformation("Received Text: {Text}", context.Message.Value);
            return Task.CompletedTask;
        }
    }
    
    public class OrderConsumer :
        IConsumer<Order>
    {
        readonly ILogger<Order> _logger;

        public OrderConsumer(ILogger<Order> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<Order> context)
        {
            _logger.LogInformation("收到订单: {Text}", context.Message.Id);
            return Task.CompletedTask;
        }
    }
}

