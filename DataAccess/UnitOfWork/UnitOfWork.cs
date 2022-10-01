using DataAccess.Abstract;
using DataAccess.Concrete.EF;
using DataAccess.Concrete.EF.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly BoynerCaseContext _context;
                private IDbContextTransaction _currentTransaction;
        public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;
        public bool HasActiveTransaction => _currentTransaction != null;

        public IProductRepository productRepository { get; private set; }

        public IAttributeRepository attributeRepository { get; private set; }

        public IAttributeValueRepository attributeValueRepository { get; private set; }

        public IProductCategoryRepository productCategoryRepository { get; private set; }

        public UnitOfWork(BoynerCaseContext context, IProductRepository productRepository)
        {
            _context = context;
            this.productRepository = productRepository;
            attributeRepository = new AttributeRepository(_context);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
            
        }



        public async Task<bool> CommitTransactionAsync(IDbContextTransaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            if (transaction != _currentTransaction) throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");
            bool isSuccess = false;
            try
            {
                int result = await SaveChangesAsync();

                transaction.Commit();
                isSuccess = true;
            }
            catch
            {
                isSuccess = false;
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }

            return isSuccess;
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (_currentTransaction != null) return null;

            _currentTransaction = await _context.Database.BeginTransactionAsync(System.Data.IsolationLevel.ReadCommitted);
            return _currentTransaction;
        }
    }
}
