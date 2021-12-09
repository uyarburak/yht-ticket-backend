using System.Threading.Tasks;

namespace YhtTicket.Common.MassTransit.Producer
{
    public interface IMessageProducer
    {
        Task PublishAsync(object message);
    }
}
