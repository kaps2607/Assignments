using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceWeb.Domain;

namespace ECommerceWeb.Application.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductByIdAsync(int Id);
        Task<Product> AddProductAsync(Product product);
        Task<Product> UpdateProductAsync(int ProductId, Product product);
        Task<bool> DeleteProductAsync(int ProductId);
    }
}
