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

namespace DataAccess.Concrete.EF
{
    public class AttributeValueRepository : EfRepository<AttributeValue>, IAttributeValueRepository
    {
        private BoynerCaseContext ctx;
        public AttributeValueRepository(BoynerCaseContext context) : base(context)
        {
            ctx = context;
        }

        public List<AttributeValue> GetAllByIds(List<int> ids)
        {
            
               return ctx.AttributeValue.Include(x=>x.Attribute).Where(a => ids.Contains(a.Id) && a.IsActive).ToList();
            
        }
    }
}
