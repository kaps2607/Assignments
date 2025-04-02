using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceWeb.Domain;
using MediatR;

namespace ECommerceWeb.Application.Features.CartFeature.Command.AddCommand
{

    public record AddCartItemCommand(string userId, int quantity, int productId) : IRequest<CartItem>;

}
