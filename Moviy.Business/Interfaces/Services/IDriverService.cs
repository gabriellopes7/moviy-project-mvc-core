using Moviy.Business.Models;

namespace Moviy.Business.Interfaces.Services
{
    public interface IDriverService : IDisposable
    {
        Task Create(Driver driver);

        Task Update(Driver driver);
        Task Delete(Guid id);


    }


}
