using Moviy.Business.Models;

namespace Moviy.Business.Interfaces
{
    public interface ITravelRepository : IRepository<Travel>
    {
        Task<Travel> GetTravelDriverBus(Guid id);

        Task<Travel> GetTravelRoute(Guid id);

        Task<Travel> GetTravelDriverBusRoute(Guid id);
    }
}
