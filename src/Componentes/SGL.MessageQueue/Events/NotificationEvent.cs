using SGL.MessageQueue.Operators;
using SGL.Util.Extensions;
using SGL.Util.Helpers.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGL.MessageQueue.Events
{
    public class NotificationEvent : INotificationEvent, IDisposable
    {
        private List<IEvent> _notification;

        private readonly IPublish _publish;

        public NotificationEvent(IPublish publish)
        {
            _publish = publish;
        }

        public void AddEvent(IEvent evento)
        {
            _notification ??= new List<IEvent>();
            _notification.Add(evento);
        }

        public void RemoveEvent(IEvent eventItem)
        {
            _notification?.Remove(eventItem);
        }

        public void ClearEvent()
        {
            _notification?.Clear();
        }

        public async Task<bool> PublishEvents()
        {
            try
            {
                if (_notification?.Any() != true) return false;

                var listLog = new List<object>();

                var tasks = _notification
                    .Select(async (domainEvent) =>
                    {
                        listLog.Add(domainEvent);
                        await _publish.DoPublish(domainEvent);
                    });


                await Task.WhenAll(tasks);

                LogHelper.AddLog(LogLevel.Information, ConstantsLogs.LOG_EVENT_MESSAGE, listLog.SerializeObject());
            }
            catch (Exception ex)
            {
                LogHelper.AddLog(LogLevel.Error, ConstantsLogs.LOG_EVENT_MESSAGE, ex.Message);
                return false;
            }
            return true;
        }

        public void Dispose()
        {
            ClearEvent();
        }
    }
}
