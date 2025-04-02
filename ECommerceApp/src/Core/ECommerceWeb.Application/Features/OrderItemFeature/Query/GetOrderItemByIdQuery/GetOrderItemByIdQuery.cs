using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceWeb.Domain;
using MediatR;

namespace ECommerceWeb.Application.Features.OrderItemFeature.Query.GetOrderItemByIdQuery
{
    public record GetOrderItemByIdQuery(int OrderItemId) : IRequest<OrderItem>;
}
