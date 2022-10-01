using Core.DataAccess;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IAttributeValueRepository : IRepository<AttributeValue>
    {
        List<AttributeValue> GetAllByIds(List<int> ids);
    }
}
