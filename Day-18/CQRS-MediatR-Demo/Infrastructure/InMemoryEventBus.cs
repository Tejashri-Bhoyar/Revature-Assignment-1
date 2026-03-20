
using System.Collections.Concurrent;

namespace CqrsMediatRDemo.Infrastructure
{
    // simple sync event bus for demo, invokes projection handlers directly
    public class InMemoryEventBus : IEventBus
    {
        private readonly IServiceProvider _provider;

        public InMemoryEventBus(IServiceProvider provider)
        {
            _provider = provider;
        }

        public async Task PublishAsync<TEvent>(TEvent @event, CancellationToken ct)
        {
            // find all handlers that implement IEventHandler<TEvent>
            var handlerType = typeof(IEventHandler<>).MakeGenericType(typeof(TEvent));
            var handlers = _provider.GetServices(handlerType);
            foreach (var handler in handlers)
            {
                var method = handlerType.GetMethod("Handle");
                if (method != null)
                {
                    var task = (Task)method.Invoke(handler, new object[] { @event, ct })!;
                    await task;
                }
            }
        }
    }
}
