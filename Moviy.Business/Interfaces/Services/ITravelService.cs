using Moviy.Business.Models;

namespace Moviy.Business.Interfaces.Services
{
    public interface ITravelService : IDisposable
    {
        Task OpenTravel(Travel travel);

        Task CloseTravel(Guid id);
    }


}
