#nullable disable

using FluentValidation.Results;
using MediatR;
using System;
using SGL.Resource.Messagens;
using SGL.Resource.Util;

namespace SGL.Resource.Messagens
{
    public abstract class CommandHandler : Message, IRequest<DefaultResult>
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected CommandHandler()
        {
            Timestamp = DateTime.Now;
        }

        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
