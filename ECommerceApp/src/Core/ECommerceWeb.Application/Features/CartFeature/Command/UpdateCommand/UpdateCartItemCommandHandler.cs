using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceWeb.Application.Interfaces;
using ECommerceWeb.Domain;
using MediatR;

namespace ECommerceWeb.Application.Features.CartFeature.Command.UpdateCommand
{
    public class UpdateCartItemCommandHandler : IRequestHandler<UpdateCartItemCommand, CartItem>
    {
        private readonly ICartRepository _cartRepository;

        public UpdateCartItemCommandHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<CartItem> Handle(UpdateCartItemCommand request, CancellationToken cancellationToken)
        {
            var cartItem = new CartItem
            {
                CartItemId = request.CartItemId,
                Quantity = request.Quantity

            };

            return await _cartRepository.UpdateCartItemAsync(request.CartItemId, cartItem);
        }
    }
}
