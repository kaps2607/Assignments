using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceWeb.Application.Interfaces;
using ECommerceWeb.Domain;
using MediatR;

namespace ECommerceWeb.Application.Features.OrderFeature.Query.GetOrderByIdQuery
{
    internal class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Orders>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderByIdQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Orders> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetOrderByIdAsync(request.id);
        }
    }
}
