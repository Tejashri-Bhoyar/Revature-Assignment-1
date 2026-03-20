
namespace CqrsMediatRDemo.Infrastructure
{
    public interface IEventBus
    {
        Task PublishAsync<TEvent>(TEvent @event, CancellationToken ct);
    }
}
