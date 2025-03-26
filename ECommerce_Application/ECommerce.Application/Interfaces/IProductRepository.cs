using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain;

namespace ECommerce.Application.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<IProductRepository>> GetProducts();
        Task<Product> GetProductById(int id);
        Task<Product> AddProductAsync(IProductRepository product);
        Task<Product> UpdateProductAsync(int ProductId, IProductRepository product);
        Task<bool> DeleteProductAsync(int ProductId);

    }
}
