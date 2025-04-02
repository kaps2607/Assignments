using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ECommerceWeb.Application.Features.OrderItemFeature.Command.DeleteOrderItemCommand
{
    public record DeleteOrderItemCommand(int OrderItemId) : IRequest<bool>;
}
