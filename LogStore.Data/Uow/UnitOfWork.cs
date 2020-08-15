using System;
using LogStore.Data.Context;
using LogStore.Data.Repositories;
using LogStore.Domain.Repositories;
using LogStore.Domain.Repositories.Uow;

namespace LogStore.Data.Uow
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private bool disposed = false;
        public DataContext context { get; set; }

        public UnitOfWork(DataContext dataContext)
        {
            context = dataContext;
        }

        public IOrderItemTypeRepository OrderItemTypeRepository
        {
            get
            {
                return new OrderItemTypeRepository(context);
            }
        }

        public IOrderRepository OrderRepository
        {
            get
            {
                return new OrderRepository(context);
            }
        }

        public IProductRepository ProductRepository
        {
            get
            {
                return new ProductRepository(context);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}