using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceWeb.Domain;
using MediatR;

namespace ECommerceWeb.Application.Features.CartFeature.Query.GetCartItemsQuery
{
    public record GetCartItemsQuery(string UserId) : IRequest<IEnumerable<CartItem>>;
}
