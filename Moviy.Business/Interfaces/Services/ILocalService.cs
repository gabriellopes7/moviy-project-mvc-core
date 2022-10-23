using Moviy.Business.Models;

namespace Moviy.Business.Interfaces.Services
{
    public interface ILocalService : IDisposable
    {
        Task Create(Local local);
        Task Delete(Guid id);
    }


}
