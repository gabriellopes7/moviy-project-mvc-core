using Moviy.Business.Interfaces;
using Moviy.Business.Models;
using Moviy.Data.Context;

namespace Moviy.Data.Repository
{
    public class DriverRepository : Repository<Driver>, IDriverRepository
    {
        public DriverRepository(MoviyDbContext context) : base(context)
        {
        }
    }
}
