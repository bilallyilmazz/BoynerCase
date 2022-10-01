using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;
namespace Core.DataAccess.EF
{
    public class EfRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IAuditableEntity

    {
        private readonly DbContext _dbContext;

        public EfRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual int SoftDelete(object EntityId)
        {
            var delete = FindById(EntityId);
            delete.IsActive = false;
            return Update(delete);
        }

        public virtual TEntity Find(Expression<Func<TEntity, bool>> Filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();

            if (includes.Length > 0)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }

            query = query.Where(x=>x.IsActive);
            return query.FirstOrDefault(Filter);


        }

        public virtual TEntity FindById(object EntityId)
        {
            DbSet<TEntity> query = _dbContext.Set<TEntity>();
            query.Where(x => x.IsActive);
            query.Find(EntityId);

            return query.FirstOrDefault();
        }

        public async Task<TEntity> Insert(TEntity Entity)
        {
            _dbContext.Set<TEntity>().Add(Entity);

            //var add = _dbContext.Entry(Entity);
            //add.State = EntityState.Added;
            //return _dbContext.SaveChanges();
            return await Task.FromResult<TEntity>(Entity);

        }

        public virtual IEnumerable<TEntity> Select(Expression<Func<TEntity, bool>> Filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();

            if (includes.Length > 0)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }

           
            query = query.Where(x => x.IsActive);
            return query.Where(Filter);

        }

        public virtual int Update(TEntity Entity)
        {
            var xx = _dbContext.Set<TEntity>().Update(Entity);

            //var add = _dbContext.Entry(Entity);
            //add.State = EntityState.Modified;
            //return _dbContext.SaveChanges();

            return 1;
        }



    }
}
