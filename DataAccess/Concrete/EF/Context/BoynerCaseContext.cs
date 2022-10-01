using Core.Entities;
using DataAccess.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Attribute = Core.Entities.Attribute;

namespace DataAccess.Concrete.EF.Context
{
    public class BoynerCaseContext:DbContext
    {
        public BoynerCaseContext():base()
        {
            
        }
        public BoynerCaseContext(DbContextOptions<BoynerCaseContext> options) : base(options) { }

 

        public DbSet<Product> Product { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<Attribute> Attribute { get; set; }
        public DbSet<AttributeValue> AttributeValue { get; set; }
        public DbSet<ProductAttribute> ProductAttribute { get; set; }
        public DbSet<CategoryAttribute> CategoryAttribute { get; set; }

     

    }
}
