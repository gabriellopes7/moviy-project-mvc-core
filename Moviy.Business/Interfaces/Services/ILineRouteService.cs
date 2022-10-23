using Moviy.Business.Models;

namespace Moviy.Business.Interfaces.Services
{
    public interface ILineRouteService : IDisposable
    {
        Task Create(LineRoute lineRoute);

        Task Update(LineRoute lineRoute);
        Task Delete(Guid id);
    }


}
