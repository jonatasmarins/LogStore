
namespace LogStore.Domain.Repositories.Uow
{
    public interface IUnitOfWork
    {   
        IOrderItemTypeRepository OrderItemTypeRepository { get; }
        IOrderRepository OrderRepository { get; }
        IProductRepository ProductRepository { get; }
    }
}