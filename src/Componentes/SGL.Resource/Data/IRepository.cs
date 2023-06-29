using System;
using SGL.Resource.Data;
using SGL.Resource.Interfaces;

namespace SGL.Resource.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
