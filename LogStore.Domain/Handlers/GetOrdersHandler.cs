using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LogStore.Domain.Commands;
using LogStore.Domain.Entities;
using LogStore.Domain.Models.Response;
using LogStore.Domain.Repositories.Uow;
using LogStore.Domain.Shared;
using MediatR;

namespace LogStore.Domain.Handlers
{
    public class GetOrdersHandler : IRequestHandler<GetOrdersCommand, IResultResponse<List<GetOrdersResponse>>>
    {
        private readonly IUnitOfWork _uow;
        public GetOrdersHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IResultResponse<List<GetOrdersResponse>>> Handle(GetOrdersCommand request, CancellationToken cancellationToken)
        {
            IResultResponse<List<GetOrdersResponse>> result = new ResultResponse<List<GetOrdersResponse>>();

            //adicionar validate - UserId not null e UserId Existe no banco

            var orders = await _uow.OrderRepository.GetByUserId(request.UserID);
            var user = await _uow.UserRepository.GetById(request.UserID);

            result.Value = ConvertToModel(orders, user);

            return result;
        }

        private List<GetOrdersResponse> ConvertToModel(IList<Order> orders, User user)
        {
            List<GetOrdersResponse> listordersResponse = new List<GetOrdersResponse>();
            //transformar em Mapper

            foreach (var item in orders)
            {
                GetOrdersResponse response = new GetOrdersResponse();

                response.OrderID = item.OrderID;
                response.CreateDate = item.CreateDate;
                response.Value = item.Value;

                response.User.UserID = user.UserID;
                response.User.Phone = user.Phone;
                response.User.Name = user.Name;
                response.User.Email = user.Email;
                response.User.DateCreate = user.DateCreate;
                response.User.Address.AddressID = user.AddressID;
                response.User.Address.City = user.Address.City;
                response.User.Address.Neighborhood = user.Address.Neighborhood;
                response.User.Address.Number = user.Address.Number;
                response.User.Address.Street = user.Address.Street;

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