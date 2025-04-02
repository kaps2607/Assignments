using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceWeb.Domain;
using MediatR;

namespace ECommerceWeb.Application.Features.OrderItemFeature.Command.UpdateOrderItemCommand
{
    public record UpdateOrderItemCommand(int OrderItemId, int Quantity) : IRequest<OrderItem>;
}
