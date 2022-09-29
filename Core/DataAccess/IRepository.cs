using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IRepository<T> where T : class,new()
    {
        T Find(Expression<Func<T, bool>> Filter = null);
        T FindById(object EntityId);
        IEnumerable<T> Select(Expression<Func<T, bool>> Filter = null);
        T Insert(T Entity);
        T Update(T Entity);
        T SoftDelete(object EntityId);
        
    }
}
