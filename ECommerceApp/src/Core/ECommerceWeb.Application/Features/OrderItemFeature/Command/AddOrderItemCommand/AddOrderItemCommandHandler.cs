using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceWeb.Application.Interfaces;
using ECommerceWeb.Domain;
using MediatR;

namespace ECommerceWeb.Application.Features.OrderItemFeature.Command.AddOrderItemCommand
{
    internal class AddOrderItemCommandHandler : IRequestHandler<AddOrderItemCommand, OrderItem>
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public AddOrderItemCommandHandler(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public async Task<OrderItem> Handle(AddOrderItemCommand request, CancellationToken cancellationToken)
        {
            return await _orderItemRepository.AddOrderItemAsync(request.OrderItem);
        }
    }
}
