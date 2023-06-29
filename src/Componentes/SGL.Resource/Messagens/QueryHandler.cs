#nullable disable

using MediatR;
using System;
using SGL.Resource.Util;

namespace SGL.Resource.Messagens
{
    public abstract class QueryHandler : IRequest<DefaultResult>
    {
        public DateTime Timestamp { get; private set; }

        protected QueryHandler()
        {
            Timestamp = DateTime.Now;
        }
    }
}
