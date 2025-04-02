using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceWeb.Application.Exceptions;
using ECommerceWeb.Application.Interfaces;
using MediatR;

namespace ECommerceWeb.Application.Features.CartFeature.Command.DeleteCommand
{
    public class DeleteCartItemCommandHandler : IRequestHandler<DeleteCartItemCommand, bool>
    {
        private readonly ICartRepository _cartRepository;

        public DeleteCartItemCommandHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<bool> Handle(DeleteCartItemCommand request, CancellationToken cancellationToken)
        {

            var cartItemFindStatus = await _cartRepository.GetCartItemByIdAsync(request.CartItemId);
            if (cartItemFindStatus is null)
            {
                throw new NotFoundException($"CartItem with Id::{request.CartItemId} not found");

            }

            return await _cartRepository.DeleteCartItemAsync(cartItemFindStatus.CartItemId);

        }
    }
}
