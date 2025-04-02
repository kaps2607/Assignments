﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceWeb.Application.Interfaces;
using ECommerceWeb.Domain;
using MediatR;

namespace ECommerceWeb.Application.Features.OrderItemFeature.Query.GetOrderItemsQuery
{
    public class GetOrderItemsQueryHandler : IRequestHandler<GetOrderItemsQuery, IEnumerable<OrderItem>>
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public GetOrderItemsQueryHandler(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public async Task<IEnumerable<OrderItem>> Handle(GetOrderItemsQuery request, CancellationToken cancellationToken)
        {
            return await _orderItemRepository.GetOrderItemsAsync(request.OrderId);
        }
    }
}
