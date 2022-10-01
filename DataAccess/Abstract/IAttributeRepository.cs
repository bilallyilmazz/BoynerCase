using Core.DataAccess;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attribute = Core.Entities.Attribute;

namespace DataAccess.Abstract
{
    public interface IAttributeRepository : IRepository<Attribute>
    {
    }
}
