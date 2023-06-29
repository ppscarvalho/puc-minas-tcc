using SGL.Resource.Messagens;
using SGL.Resource.Messagens.CommonMessage.Notifications;
using SGL.Resource.Util;
using System.Threading.Tasks;

namespace SGL.Resource.Communication.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T events) where T : Event;
        Task<DefaultResult> SendCommand<T>(T command) where T : CommandHandler;
        Task PublishNotification<T>(T notification) where T : DomainNotification;
    }
}
