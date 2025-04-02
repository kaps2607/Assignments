﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceWeb.Application.Interfaces;
using ECommerceWeb.Domain;
using ECommerceWeb.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ECommerceWeb.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        protected readonly ApplicationDbContext _eCommerceDbContext;
        public ProductRepository(ApplicationDbContext eCommerceDbContext)
        {
            _eCommerceDbContext = eCommerceDbContext;
        }
        public async Task<Product> AddProductAsync(Product product)
        {
            await _eCommerceDbContext.Products.AddAsync(product);
            await _eCommerceDbContext.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await GetProductByIdAsync(id);
            if (product is not null)
            {
                _eCommerceDbContext.Products.Remove(product);
                return await _eCommerceDbContext.SaveChangesAsync() > 0;
            }
            return false;
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _eCommerceDbContext.Products.FirstOrDefaultAsync(b => b.ProductId == id);
        }
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _eCommerceDbContext.Products.Include(c => c.Category).ToListAsync();
        }
        public Task<Product> UpdateProductAsync(int ProductId, Product product)
        {
            throw new NotImplementedException();
        }
    }
}
