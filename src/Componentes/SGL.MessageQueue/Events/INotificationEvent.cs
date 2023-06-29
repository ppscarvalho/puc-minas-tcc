#nullable disable

using System.Threading.Tasks;
#nullable disable

using SGL.MessageQueue.Events;

namespace SGL.MessageQueue.Events
{
    public interface INotificationEvent
    {
        void AddEvent(IEvent evento);

        void RemoveEvent(IEvent eventItem);

        void ClearEvent();

        Task<bool> PublishEvents();
    }
}
