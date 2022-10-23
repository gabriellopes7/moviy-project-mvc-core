using Moviy.Business.Models;

namespace Moviy.Business.Interfaces
{
    public interface ILineRouteRepository : IRepository<LineRoute>
    {
        Task<LineRoute> GetRouteLocals(Guid id);

    }
}
