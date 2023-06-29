using System.Threading.Tasks;

namespace SGL.Resource.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
