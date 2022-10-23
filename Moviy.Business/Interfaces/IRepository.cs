using Moviy.Business.Models;
using System.Linq.Expressions;

namespace Moviy.Business.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Create(TEntity entity);

        Task<TEntity> Get(Guid id);

        Task<List<TEntity>> GetAll();

        Task Update(TEntity entity);

        Task Delete(Guid id);

        //Buscar qualquer entidade por qualquer parâmetro desde que ela retorne um boolean
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);

        Task<int> SaveChanges(); //Int é o numero de linhas afetadas

    }
}
