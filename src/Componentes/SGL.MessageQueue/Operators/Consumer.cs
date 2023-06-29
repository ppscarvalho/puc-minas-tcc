using MassTransit;
using System.Threading.Tasks;

namespace SGL.MessageQueue.Operators
{
    public abstract class Consumer<T> : IConsumer<T> where T : class
    {
        public async Task Consume(ConsumeContext<T> context)
        {
            await ConsumeContex(new ConsumerContext<T>(context));
        }

        public abstract Task ConsumeContex(ConsumerContext<T> context);
    }
}
