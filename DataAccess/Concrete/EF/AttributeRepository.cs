using Core.DataAccess.EF;
using Core.Entities;
using DataAccess.Abstract;
using DataAccess.Concrete.EF.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attribute = Core.Entities.Attribute;

namespace DataAccess.Concrete.EF
{
    public class AttributeRepository : EfRepository<Attribute>, IAttributeRepository
    {
        public AttributeRepository(BoynerCaseContext context) : base(context)
        {
            
        }


    }
}
