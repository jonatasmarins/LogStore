using System;
using System.Threading.Tasks;
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

        public IOrderItemRepository OrderItemRepository
        {
            get
            {
                return new OrderItemRepository(context);
            }
        }

        public IProductRepository ProductRepository
        {
            get
            {
                return new ProductRepository(context);
            }
        }

        public IOrderUserRepository OrderUserRepository
        {
            get
            {
                return new OrderUserRepository(context);
            }
        }

        public IAddressRepository AddressRepository
        {
            get
            {
                return new AddressRepository(context);
            }
        }

        public IOrderAddressRepository OrderAddressRepository
        {
            get
            {
                return new OrderAddressRepository(context);
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                return new UserRepository(context);
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

        public async Task<int> SaveChange()
        {
            return await context.SaveChangesAsync();
        }
    }
}