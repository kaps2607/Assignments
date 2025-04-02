using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceWeb.Application.Interfaces;
using ECommerceWeb.Domain;
using MediatR;

namespace ECommerceWeb.Application.Features.OrderFeature.Command.UpdateCommand
{
    internal class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Orders>
    {
        readonly IOrderRepository _orderRepository;

        public UpdateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<Orders> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {

            if (request.order == null || request.order.OrderId <= 0)
            {
                throw new ArgumentException("Invalid order data.");
            }
            return await _orderRepository.UpdateOrderAsync(request.order.OrderId, request.order);
        }
    }
}
