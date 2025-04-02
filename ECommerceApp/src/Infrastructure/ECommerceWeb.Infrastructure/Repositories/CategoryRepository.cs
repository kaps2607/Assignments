using System;
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
    public class CategoryRepository : ICategoryRepository
    {
        readonly ApplicationDbContext _eCommerceDbContext;

        public CategoryRepository(ApplicationDbContext eCommerceDbContext)
        {
            _eCommerceDbContext = eCommerceDbContext;
        }


        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _eCommerceDbContext.Categories.ToListAsync();
        }


        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _eCommerceDbContext.Categories.FindAsync(id);
        }


        public async Task<Category> AddCategoryAsync(Category category)
        {
            await _eCommerceDbContext.Categories.AddAsync(category);
            await _eCommerceDbContext.SaveChangesAsync();
            return category;
        }


        public async Task<Category> UpdateCategoryAsync(int categoryId, Category category)
        {
            if (categoryId != category.CategoryId)
            {
                throw new ArgumentException("Category ID mismatch");
            }

            _eCommerceDbContext.Entry(category).State = EntityState.Modified;
            await _eCommerceDbContext.SaveChangesAsync();
            return category;
        }


        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await _eCommerceDbContext.Categories.FindAsync(id);
            if (category == null)
            {
                return false;
            }
            _eCommerceDbContext.Categories.Remove(category);
            await _eCommerceDbContext.SaveChangesAsync();
            return true;
        }
    }
}
