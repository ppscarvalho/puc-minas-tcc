using SGL.MessageQueue.Events;

namespace SGL.MessageQueue.Models
{
    public class RequestIn : IEvent
    {
        public string? Host { get; set; }
        public string? Queue { get; set; }
        public string? Result { get; set; }
    }
}
