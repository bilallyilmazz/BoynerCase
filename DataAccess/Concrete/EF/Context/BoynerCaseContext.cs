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
    public class BoynerCaseContext : DbContext
    {
        public BoynerCaseContext() : base()
        {

        }
        public BoynerCaseContext(DbContextOptions<BoynerCaseContext> options) : base(options) { }



        public DbSet<Product> Product { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<Attribute> Attribute { get; set; }
        public DbSet<AttributeValue> AttributeValue { get; set; }
        public DbSet<ProductAttribute> ProductAttribute { get; set; }
        public DbSet<CategoryAttribute> CategoryAttribute { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region ProductCategory_Initial_Create_Data
            modelBuilder.Entity<ProductCategory>()
                .HasData(
                    new ProductCategory
                    {
                        Id = 1,
                        Name = "Erkek Kazak & Hırka",
                        AddedDate = DateTime.Now,
                        IsActive = true,
                        ModifiedDate = DateTime.Now
                    },
                   new ProductCategory
                   {
                       Id = 2,
                       Name = "Kadın Kazak & Hırka",
                       AddedDate = DateTime.Now,
                       IsActive = true,
                       ModifiedDate = DateTime.Now
                   },
                   new ProductCategory
                   {
                       Id = 3,
                       Name = "Çocuk Kazak & Hırka",
                       AddedDate = DateTime.Now,
                       IsActive = true,
                       ModifiedDate = DateTime.Now
                   }
                ); 
            #endregion

            #region Attribute_Initial_Create_Data
            modelBuilder.Entity<Attribute>()
               .HasData(
                   new Attribute
                   {
                       Id = 1,
                       Name = "Brand",
                       AddedDate = DateTime.Now,
                       IsActive = true,
                       ModifiedDate = DateTime.Now
                   },
                  new Attribute
                  {
                      Id = 2,
                      Name = "Size",
                      AddedDate = DateTime.Now,
                      IsActive = true,
                      ModifiedDate = DateTime.Now
                  },
                  new Attribute
                  {
                      Id = 3,
                      Name = "Color",
                      AddedDate = DateTime.Now,
                      IsActive = true,
                      ModifiedDate = DateTime.Now
                  },
                  new Attribute
                  {
                      Id = 4,
                      Name = "Screen Size",
                      AddedDate = DateTime.Now,
                      IsActive = true,
                      ModifiedDate = DateTime.Now
                  },
                  new Attribute
                  {
                      Id = 5,
                      Name = "OS",
                      AddedDate = DateTime.Now,
                      IsActive = true,
                      ModifiedDate = DateTime.Now
                  },
                  new Attribute
                  {
                      Id = 6,
                      Name = "Gender",
                      AddedDate = DateTime.Now,
                      IsActive = true,
                      ModifiedDate = DateTime.Now
                  }
               ); 
            #endregion

            #region AttributeValue_Initial_Create_Data
            modelBuilder.Entity<AttributeValue>()
               .HasData(
                   new AttributeValue
                   {
                       Id = 1,
                       Name = "Fabrika",
                       AttributeId = 1,
                       AddedDate = DateTime.Now,
                       IsActive = true,
                       ModifiedDate = DateTime.Now
                   },
                  new AttributeValue
                  {
                      Id = 2,
                      Name = "U.S. Polo",
                      AttributeId = 1,
                      AddedDate = DateTime.Now,
                      IsActive = true,
                      ModifiedDate = DateTime.Now
                  },
                 new AttributeValue
                 {
                     Id = 3,
                     Name = "XL",
                     AttributeId = 2,
                     AddedDate = DateTime.Now,
                     IsActive = true,
                     ModifiedDate = DateTime.Now
                 },
                 new AttributeValue
                 {
                     Id = 4,
                     Name = "L",
                     AttributeId = 2,
                     AddedDate = DateTime.Now,
                     IsActive = true,
                     ModifiedDate = DateTime.Now
                 },
                  new AttributeValue
                  {
                      Id = 5,
                      Name = "Yeşil",
                      AttributeId = 3,
                      AddedDate = DateTime.Now,
                      IsActive = true,
                      ModifiedDate = DateTime.Now
                  },
                  new AttributeValue
                  {
                      Id = 6,
                      Name = "Siyah",
                      AttributeId = 3,
                      AddedDate = DateTime.Now,
                      IsActive = true,
                      ModifiedDate = DateTime.Now
                  },
                 new AttributeValue
                 {
                     Id = 7,
                     Name = "4 inc",
                     AttributeId = 4,
                     AddedDate = DateTime.Now,
                     IsActive = true,
                     ModifiedDate = DateTime.Now
                 },
                 new AttributeValue
                 {
                     Id = 8,
                     Name = "5 inc",
                     AttributeId = 4,
                     AddedDate = DateTime.Now,
                     IsActive = true,
                     ModifiedDate = DateTime.Now
                 }, new AttributeValue
                 {
                     Id = 9,
                     Name = "Android",
                     AttributeId = 5,
                     AddedDate = DateTime.Now,
                     IsActive = true,
                     ModifiedDate = DateTime.Now
                 },
                 new AttributeValue
                 {
                     Id = 10,
                     Name = "iOS",
                     AttributeId = 5,
                     AddedDate = DateTime.Now,
                     IsActive = true,
                     ModifiedDate = DateTime.Now
                 },
                 new AttributeValue
                 {
                     Id = 11,
                     Name = "Erkek",
                     AttributeId = 6,
                     AddedDate = DateTime.Now,
                     IsActive = true,
                     ModifiedDate = DateTime.Now
                 },
                 new AttributeValue
                 {
                     Id = 12,
                     Name = "Kadın",
                     AttributeId = 6,
                     AddedDate = DateTime.Now,
                     IsActive = true,
                     ModifiedDate = DateTime.Now
                 }

               );
            #endregion

            #region Product_Initial_Create_Data
            modelBuilder.Entity<Product>()
                    .HasData(
                        new Product
                        {
                            Id = 1,
                            Name = "Classics Bisiklet Yaka İndigo Melanj Desenli Erkek Kazak",
                            Price = 379.99m,
                            ProductCategoryId = 1,
                            AddedDate = DateTime.Now,
                            IsActive = true,
                            ModifiedDate = DateTime.Now
                        },
                       new Product
                       {
                           Id = 2,
                           Name = "Yeşil Kadın Kazak",
                           ProductCategoryId = 2,
                           Price = 679.99m,
                           AddedDate = DateTime.Now,
                           IsActive = true,
                           ModifiedDate = DateTime.Now
                       },
                       new Product
                       {
                           Id = 3,
                           Name = "Mavi Çocuk Kazak",
                           ProductCategoryId = 3,
                           Price = 439.99m,
                           AddedDate = DateTime.Now,
                           IsActive = true,
                           ModifiedDate = DateTime.Now
                       }
                    );
            #endregion

            #region ProductAttribute_Inial_Create_Data
            modelBuilder.Entity<ProductAttribute>()
                    .HasData(
                        new ProductAttribute
                        {
                            Id = 1,
                            AttributeValueId = 1,
                            ProductId = 1,
                            AddedDate = DateTime.Now,
                            IsActive = true,
                            ModifiedDate = DateTime.Now
                        },
                       new ProductAttribute
                       {
                           Id = 2,
                           AttributeValueId = 5,
                           ProductId = 1,
                           AddedDate = DateTime.Now,
                           IsActive = true,
                           ModifiedDate = DateTime.Now
                       },
                       new ProductAttribute
                       {
                           Id = 3,
                           AttributeValueId = 11,
                           ProductId = 1,
                           AddedDate = DateTime.Now,
                           IsActive = true,
                           ModifiedDate = DateTime.Now
                       },
                        new ProductAttribute
                        {
                            Id = 4,
                            AttributeValueId = 1,
                            ProductId = 2,
                            AddedDate = DateTime.Now,
                            IsActive = true,
                            ModifiedDate = DateTime.Now
                        },
                       new ProductAttribute
                       {
                           Id = 5,
                           AttributeValueId = 5,
                           ProductId = 2,
                           AddedDate = DateTime.Now,
                           IsActive = true,
                           ModifiedDate = DateTime.Now
                       },
                       new ProductAttribute
                       {
                           Id = 6,
                           AttributeValueId = 11,
                           ProductId = 2,
                           AddedDate = DateTime.Now,
                           IsActive = true,
                           ModifiedDate = DateTime.Now
                       },
                        new ProductAttribute
                        {
                            Id = 7,
                            AttributeValueId = 1,
                            ProductId = 3,
                            AddedDate = DateTime.Now,
                            IsActive = true,
                            ModifiedDate = DateTime.Now
                        },
                       new ProductAttribute
                       {
                           Id = 8,
                           AttributeValueId = 5,
                           ProductId = 3,
                           AddedDate = DateTime.Now,
                           IsActive = true,
                           ModifiedDate = DateTime.Now
                       },
                       new ProductAttribute
                       {
                           Id = 9,
                           AttributeValueId = 11,
                           ProductId = 3,
                           AddedDate = DateTime.Now,
                           IsActive = true,
                           ModifiedDate = DateTime.Now
                       }
                    ); 
            #endregion
        }
    }
}
