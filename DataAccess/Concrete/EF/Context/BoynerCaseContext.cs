using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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

    }
}
