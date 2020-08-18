using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LogStore.Domain.Commands;
using LogStore.Domain.Entities;
using LogStore.Domain.Models.Response;
using LogStore.Domain.Repositories.Uow;
using LogStore.Domain.Shared;
using LogStore.Domain.Validators.Properties;
using MediatR;

namespace LogStore.Domain.Handlers
{
    public class GetOrdersWithOutUser: IRequestHandler<GetOrdersWithOutUserCommand, IResultResponse<List<GetOrdersWithOutUserResponse>>>
    {
        private readonly IUnitOfWork _uow;
        public GetOrdersWithOutUser(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IResultResponse<List<GetOrdersWithOutUserResponse>>> Handle(GetOrdersWithOutUserCommand request, CancellationToken cancellationToken)
        {
            IResultResponse<List<GetOrdersWithOutUserResponse>> result = new ResultResponse<List<GetOrdersWithOutUserResponse>>();
            var validator = await new AddressIDPropertyValidator(_uow).ValidateAsync(request.AddressID);

            if (!validator.IsValid)
            {
                result.AddMessage(validator.Errors);
                return result;
            }

            var orders = await _uow.OrderRepository.GetByAddressId(request.AddressID);
            var address = await _uow.AddressRepository.GetById(request.AddressID);

            result.Value = ConvertToModel(orders, address);

            return result;
        }

        private List<GetOrdersWithOutUserResponse> ConvertToModel(IList<Order> orders, Address address)
        {
            List<GetOrdersWithOutUserResponse> listordersResponse = new List<GetOrdersWithOutUserResponse>();
            
            //transformar em Mapper

            foreach (var item in orders)
            {
                GetOrdersWithOutUserResponse response = new GetOrdersWithOutUserResponse();

                response.OrderID = item.OrderID;
                response.CreateDate = item.CreateDate;
                response.Value = item.Value;

                response.Address.AddressID = address.AddressID;
                response.Address.City = address.City;
                response.Address.Neighborhood = address.Neighborhood;
                response.Address.Number = address.Number;
                response.Address.Street = address.Street;

                foreach (var subItem in item.Items)
                {
                    GetOrderItemResponse orderItem = new GetOrderItemResponse();
                    orderItem.OrderItemID = subItem.OrderItemID;
                    orderItem.Description = subItem.Description;
                    orderItem.Value = subItem.Value;

                    orderItem.OrderItemType.OrderItemTypeID = subItem.OrderItemType.OrderItemTypeID;
                    orderItem.OrderItemType.Name = subItem.OrderItemType.Name;
                    orderItem.OrderItemType.Description = subItem.OrderItemType.Description;
                    orderItem.OrderItemType.QuantityProduct = subItem.OrderItemType.QuantityProduct;

                    foreach (var product in subItem.Products)
                    {
                        orderItem.Product.Add(
                            new GetProductResponse(
                                product.ProductID,
                                product.Product.Name,
                                product.Product.Description,
                                product.Product.Value
                            )
                        );
                    }

                    response.Items.Add(orderItem);
                }

                listordersResponse.Add(response);
            }

            return listordersResponse;
        }
    }
}