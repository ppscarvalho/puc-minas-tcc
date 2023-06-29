using MassTransit;
using System;
using SGL.MessageQueue.Events;

namespace SGL.MessageQueue.Configuration
{
	public interface IPublisher : IEvent
	{
		public string Queue { get; }
		public Action<IRabbitMqBusFactoryConfigurator> Config { get; }
	}
}
