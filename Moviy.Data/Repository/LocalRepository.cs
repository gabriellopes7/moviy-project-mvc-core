using Microsoft.EntityFrameworkCore;
using Moviy.Business.Interfaces;
using Moviy.Business.Models;
using Moviy.Data.Context;

namespace Moviy.Data.Repository
{
    public class LocalRepository : Repository<Local>, ILocalRepository
    {
        public LocalRepository(MoviyDbContext context) : base(context)
        {
        }

        public async Task<List<Local>> GetLocalsList(string query)
        {
            return await Db.Locals
                .Where(l => l.City.ToLower().Contains(query)
                || l.Country.Contains(query)
                || l.Street.ToLower().Contains(query)
                || l.District.ToLower().Contains(query)
                || l.Code.ToLower().Contains(query))
                .ToListAsync();

        }


        public async Task<Local> GetLocalPerCode(string code)
        {
            return await DbSet.AsNoTracking()
                .Where(l => l.Code.Equals(code)).FirstOrDefaultAsync();

        }
    }
}
