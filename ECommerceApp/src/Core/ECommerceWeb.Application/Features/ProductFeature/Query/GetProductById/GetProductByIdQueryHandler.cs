using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceWeb.Application.Interfaces;
using ECommerceWeb.Domain;
using MediatR;

namespace ECommerceWeb.Application.Features.ProductFeature.Query.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        readonly IProductRepository _productRepository;
        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductByIdAsync(request.id);
            return product;
        }
    }
}
