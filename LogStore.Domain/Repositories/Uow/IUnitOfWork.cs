
using System.Threading.Tasks;

namespace LogStore.Domain.Repositories.Uow
{
    public interface IUnitOfWork
    {   
        IOrderRepository OrderRepository { get; }
        IOrderItemRepository OrderItemRepository { get; }
        IOrderItemTypeRepository OrderItemTypeRepository { get; }
        IProductRepository ProductRepository { get; }
        IOrderUserRepository OrderUserRepository { get; }
        IAddressRepository AddressRepository { get; }
        IOrderAddressRepository OrderAddressRepository { get; }

        Task<int> SaveChange();
    }
}