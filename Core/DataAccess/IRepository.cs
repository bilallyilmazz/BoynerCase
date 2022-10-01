using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{

    public interface IRepository<T>  where T : class,IAuditableEntity
    {
        T Find(Expression<Func<T, bool>> Filter = null, params Expression<Func<T, object>>[] includes);
        T FindById(object EntityId);
        IEnumerable<T> Select(Expression<Func<T, bool>> Filter = null, params Expression<Func<T, object>>[] includes);
        Task<T> Insert(T Entity);
        int Update(T Entity);
        int SoftDelete(object EntityId);
        
    }
}
