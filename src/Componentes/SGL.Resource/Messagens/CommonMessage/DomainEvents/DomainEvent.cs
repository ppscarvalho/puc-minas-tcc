using System;
using SGL.Resource.Messagens;

namespace SGL.Resource.Messagens.CommonMessage.DomainEvents
{
    public class DomainEvent : Event
    {
        public DomainEvent(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }
    }
}
