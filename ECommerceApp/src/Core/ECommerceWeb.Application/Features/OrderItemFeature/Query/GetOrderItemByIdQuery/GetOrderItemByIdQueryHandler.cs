﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceWeb.Application.Interfaces;
using ECommerceWeb.Domain;
using MediatR;

namespace ECommerceWeb.Application.Features.OrderItemFeature.Query.GetOrderItemByIdQuery
{
    public class GetOrderItemByIdQueryHandler : IRequestHandler<GetOrderItemByIdQuery, OrderItem>
    {
        readonly IOrderItemRepository _orderItemRepository;

        public GetOrderItemByIdQueryHandler(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public async Task<OrderItem> Handle(GetOrderItemByIdQuery request, CancellationToken cancellationToken)
        {
            return await _orderItemRepository.GetOrderItemByIdAsync(request.OrderItemId);
        }
    }
}
