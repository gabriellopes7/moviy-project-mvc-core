using Microsoft.EntityFrameworkCore;
using Moviy.Business.Interfaces;
using Moviy.Business.Models;
using Moviy.Data.Context;
using System.Linq.Expressions;

namespace Moviy.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly MoviyDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(MoviyDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public virtual async Task<TEntity> Get(Guid id)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            //Pega uma lista de forma assincrona em que o dbset atenda ao que foi passado na função predicate
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task Create(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();

        }
        public virtual async Task Update(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Delete(Guid id)
        {
            DbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }


        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }



        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
