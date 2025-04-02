using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceWeb.Application.Exceptions;
using ECommerceWeb.Application.Interfaces;
using MediatR;

namespace ECommerceWeb.Application.Features.ProductFeature.Command.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        readonly IProductRepository _repository;

        public DeleteProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var findProduct = await _repository.GetProductByIdAsync(request.id);
            if (findProduct is null)
            {

                throw new NotFoundException($"Product with Id::{request.id} not found");
            }
            return await _repository.DeleteProductAsync(findProduct.ProductId);
        }
    }
}
