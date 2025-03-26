using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.Interfaces;
using ECommerce.Domain;

namespace ECommerce.Infrastructure.Repository
{
    internal class ProductRepository : IProductRepository
    {
        public Task<Product> AddProductAsync(IProductRepository product)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProductAsync(int ProductId)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IProductRepository>> GetProducts()
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateProductAsync(int ProductId, IProductRepository product)
        {
            throw new NotImplementedException();
        }
    }
}
