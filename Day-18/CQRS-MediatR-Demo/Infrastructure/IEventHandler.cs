
namespace CqrsMediatRDemo.Infrastructure
{
    public interface IEventHandler<TEvent>
    {
        Task Handle(TEvent @event, CancellationToken ct);
    }
}
