using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceWeb.Application.Interfaces;
using ECommerceWeb.Domain;
using MediatR;

namespace ECommerceWeb.Application.Features.CartFeature.Query.GetCartItemByIdQueryHandler
{
    public class GetCartItemByIdQueryHandler : IRequestHandler<GetCartItemByIdQuery, CartItem>
    {
        private readonly ICartRepository _cartRepository;

        public GetCartItemByIdQueryHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<CartItem> Handle(GetCartItemByIdQuery request, CancellationToken cancellationToken)
        {
            return await _cartRepository.GetCartItemByIdAsync(request.CartItemId);
        }
    }
}
