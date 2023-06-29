using System.Collections.Generic;
using SGL.MessageQueue.Configuration;

namespace SGL.MessageQueue.Configuration
{
	public class BuilderBus
	{
		public BuilderBus(string connectionString)
		{
			ConnectionString = connectionString;
		}

		public string ConnectionString { get; private set; }

		public HashSet<IPublisher> Publishers { get; set; }
		public HashSet<Consumer> Consumers { get; set; }

		public Retry Retry { get; set; }
	}
}
