using System.Threading.Tasks;

namespace SGL.MessageQueue.Operators
{
    public interface IPublish
    {
        Task DoPublish<T>(T obj);
        Task DoSend<T>(T obj);
        Task<TResponse> DoRPC<TRequest, TResponse>(TRequest obj, int timeout = 120) where TRequest : class where TResponse : class;
    }
}
