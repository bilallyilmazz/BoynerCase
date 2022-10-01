using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        IProductRepository productRepository { get; }
        IAttributeRepository attributeRepository { get; }
        IAttributeValueRepository attributeValueRepository { get; }
        IProductCategoryRepository productCategoryRepository { get; }


        Task<int> SaveChangesAsync();
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task<bool> CommitTransactionAsync(IDbContextTransaction transaction);
    }
}
