using Moviy.Business.Models;

namespace Moviy.Business.Interfaces.Services
{
    public interface IBusService : IDisposable
    {
        Task Create(Bus bus);

        Task Update(Bus bus);
        Task Delete(Guid id);

    }


}
