using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceWeb.Application.Interfaces;
using ECommerceWeb.Domain;
using MediatR;

namespace ECommerceWeb.Application.Features.CartFeature.Command.AddCommand
{
    public class AddCartItemCommandHandler : IRequestHandler<AddCartItemCommand, CartItem>
    {
        private readonly ICartRepository _cartRepository;

        public AddCartItemCommandHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<CartItem> Handle(AddCartItemCommand request, CancellationToken cancellationToken)
        {
            return await _cartRepository.AddCartItemAsync(request.cartItem);
        }
    }
}
