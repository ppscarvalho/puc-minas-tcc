using System.Net;
using SGL.Util.Exceptions;

namespace SGL.Util.Exceptions
{
	public interface INotificationError
	{
		void AddError(string error);

		void AddError(Error error);

		void RemoveError(Error error);

		void Clear();

		void Publish(HttpStatusCode statusCode = HttpStatusCode.BadRequest);
	}
}
