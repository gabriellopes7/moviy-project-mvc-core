using Microsoft.EntityFrameworkCore;
using Moviy.Business.Interfaces;
using Moviy.Business.Models;
using Moviy.Data.Context;

namespace Moviy.Data.Repository
{
    public class TravelRepository : Repository<Travel>, ITravelRepository
    {

        public TravelRepository(MoviyDbContext context) : base(context)
        {

        }

        public override async Task<List<Travel>> GetAll()
        {
            return await
                    Db.Travels
                .Include(d => d.Driver)
                .Include(b => b.Bus)
                .Include(r => r.LineRoute)
                .ThenInclude(s => s.StartPoint)
                .Include(r => r.LineRoute)
                .ThenInclude(e => e.EndPoint)
                .ToListAsync();
        }

        public async Task<Travel> GetTravelDriverBus(Guid id)
        {
            return await
                Db.Travels.AsNoTracking()
                .Include(d => d.Driver)
                .Include(b => b.Bus)
                .FirstOrDefaultAsync();
        }


        public async Task<Travel> GetTravelDriverBusRoute(Guid id)
        {
            //Tirar duvida de como trazer as rotas completas...
            return await Db.Travels.AsNoTracking()
                .Include(d => d.Driver)
                .Include(b => b.Bus)
                .Include(r => r.LineRoute)
                .Include(r => r.LineRoute).ThenInclude(s => s.StartPoint)
                .Include(r => r.LineRoute).ThenInclude(e => e.EndPoint)
                .FirstOrDefaultAsync(t => t.Id == id);

        }


        public async Task<Travel> GetTravelRoute(Guid id)
        {
            return await Db.Travels.AsNoTracking()
                .Include(r => r.LineRoute)
                .FirstOrDefaultAsync();
        }
    }
}
