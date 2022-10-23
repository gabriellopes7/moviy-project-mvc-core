using Moviy.Business.Models;

namespace Moviy.Business.Interfaces
{
    public interface ILocalRepository : IRepository<Local>
    {
        Task<List<Local>> GetLocalsList(string searchText);

        Task<Local> GetLocalPerCode(string code);
    }
}
