using System;

namespace SGL.MessageQueue.Configuration
{
	public class Retry
	{
		public Retry(int retryCount, TimeSpan interval)
		{
			RetryCount = retryCount;
			Interval = interval;
		}

		public int RetryCount { get; private set; }
		public TimeSpan Interval { get; private set; }
	}
}
