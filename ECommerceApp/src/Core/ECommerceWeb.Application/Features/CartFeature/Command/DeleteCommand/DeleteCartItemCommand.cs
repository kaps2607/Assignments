using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ECommerceWeb.Application.Features.CartFeature.Command.DeleteCommand
{
    public record DeleteCartItemCommand(int CartItemId) : IRequest<bool>;
}
