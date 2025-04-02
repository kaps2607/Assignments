using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceWeb.Application.Interfaces;
using ECommerceWeb.Domain;
using MediatR;

namespace ECommerceWeb.Application.Features.OrderFeature.Query.GetAllOrdersQuery
{
    internal class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, IEnumerable<Orders>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrdersQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<Orders>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetOrdersAsync();
        }
    }
}
