using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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


            return query.FirstOrDefault(Filter);


        }

        public virtual TEntity FindById(object EntityId)
        {

            return _dbContext.Set<TEntity>().Find(EntityId);

        }

        public virtual int Insert(TEntity Entity)
        {
            var add = _dbContext.Entry(Entity);
            add.State = EntityState.Added;
            return _dbContext.SaveChanges();
    
        }

        public virtual IEnumerable<TEntity> Select(Expression<Func<TEntity, bool>> Filter = null)
        {

            return _dbContext.Set<TEntity>().Where(Filter);

        }

        public virtual int Update(TEntity Entity)
        {

            var add = _dbContext.Entry(Entity);
            add.State = EntityState.Modified;
            return _dbContext.SaveChanges();


        }
    }
}
