using System;
using MassTransit;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace work
{
    public class Worker : BackgroundService
    {
        readonly IBus _bus;

        public Worker(IBus bus)
        {
            _bus = bus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _bus.Publish(new Order
                {
                    Id = Guid.NewGuid().ToString()
                });
                await _bus.Publish(new GettingStarted { Value = $"The time is {DateTimeOffset.Now}" }, stoppingToken);
                await Task.Delay(1000, stoppingToken);
            }
            
            
        }
    }
}