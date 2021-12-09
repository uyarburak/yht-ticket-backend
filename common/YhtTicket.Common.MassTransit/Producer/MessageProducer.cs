using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace YhtTicket.Common.MassTransit.Producer
{
    public class MessageProducer : IMessageProducer
    {
        private readonly ILogger<MessageProducer> _logger;
        private readonly IBus _bus;

        public MessageProducer(IBus bus)
        {
            _bus = bus;
        }

        public async Task PublishAsync(object message)
        {
            try
            {
                await _bus.Publish(message);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error has occured in MessageProducer while publishing a message");
                throw;
            }
        }
    }
}
