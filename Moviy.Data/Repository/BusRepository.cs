using Moviy.Business.Interfaces;
using Moviy.Business.Models;
using Moviy.Data.Context;

namespace Moviy.Data.Repository
{
    public class BusRepository : Repository<Bus>, IBusRepository
    {
        public BusRepository(MoviyDbContext context) : base(context)
        {
        }

    }
}
