using Microsoft.EntityFrameworkCore;
using Moviy.Business.Interfaces;
using Moviy.Business.Models;
using Moviy.Data.Context;

namespace Moviy.Data.Repository
{
    public class LineRouteRepository : Repository<LineRoute>, ILineRouteRepository
    {
        public LineRouteRepository(MoviyDbContext context) : base(context)
        {
        }

        public async Task<LineRoute> GetRouteLocals(Guid id)
        {
            return await Db.LineRoutes
                .Include(s => s.StartPoint)
                .Include(e => e.EndPoint)
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async override Task<List<LineRoute>> GetAll()
        {
            return await Db.LineRoutes.AsNoTracking()
                .Include(s => s.StartPoint)
                .Include(e => e.EndPoint).ToListAsync();
        }
    }
}
