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
    public class EfRepository<TEntity, TContext> : IRepository<TEntity> 
        where TEntity : AuditableEntity,new()
        where TContext : DbContext,new()
    {
        public virtual TEntity SoftDelete(object EntityId)
        {
            try
            {
                using (var context=new TContext())
                {
                   TEntity entityDelete = FindById(EntityId);
                    entityDelete.IsActive = false;

                    return Update(entityDelete);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public virtual TEntity Find(Expression<Func<TEntity, bool>> Filter = null)
        {
            try
            {
                using (var context = new TContext())
                {
                    return context.Set<TEntity>().FirstOrDefault(Filter);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public virtual TEntity FindById(object EntityId)
        {
            try
            {
                using (var context = new TContext())
                {
                    return context.Set<TEntity>().Find(EntityId);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public virtual TEntity Insert(TEntity Entity)
        {
            try
            {
                using (var context = new TContext())
                {
                   var add=context.Entry(Entity);
                    add.State= EntityState.Added;
                    context.SaveChanges();
                    return Entity;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public virtual IEnumerable<TEntity> Select(Expression<Func<TEntity, bool>> Filter = null)
        {
            try
            {
                using (var context = new TContext())
                {
                    return context.Set<TEntity>().Where(Filter);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public virtual TEntity Update(TEntity Entity)
        {
            try
            {
                using (var context = new TContext())
                {
                    var add = context.Entry(Entity);
                    add.State = EntityState.Modified;
                    context.SaveChanges();
                    return Entity;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
