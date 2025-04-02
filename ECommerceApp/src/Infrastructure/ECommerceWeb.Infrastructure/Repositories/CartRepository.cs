using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceWeb.Application.Interfaces;
using ECommerceWeb.Domain;
using ECommerceWeb.Infrastructure.Context;
//using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerceWeb.Infrastructure.Repositories
{
    public class CartRepository : ICartRepository
    {
        readonly ApplicationDbContext _context;
        //readonly UserManager<ApplicationUser> _userManager;

        public CartRepository(ApplicationDbContext context)
        {
            _context = context;
            //_userManager = userManager;
        }


        public async Task<IEnumerable<CartItem>> GetCartItemsAsync(string userId)
        {
            return await _context.CartItems
                .Include(c => c.Product)
                .Where(c => c.UserId.Equals(userId))
                .ToListAsync();
        }


        public async Task<CartItem> GetCartItemByIdAsync(int cartItemId)
        {

            return await _context.CartItems
                .Include(c => c.Product)
                .FirstOrDefaultAsync(c => c.CartItemId == cartItemId);
        }


        public async Task<CartItem> AddCartItemAsync(string userId, int quantity, int productId)
        {
            var cartItem = new CartItem
            {
                ProductId = productId,
                UserId = userId,
                Quantity = quantity

            };

            await _context.CartItems.AddAsync(cartItem);
            await _context.SaveChangesAsync();
            return cartItem;
        }


        public async Task<CartItem> UpdateCartItemAsync(int cartItemId, CartItem cartItem)
        {
            var existingCartItem = await GetCartItemByIdAsync(cartItemId);
            if (existingCartItem == null)
            {
                throw new ArgumentException("Cart item not found");
            }

            existingCartItem.Quantity = cartItem.Quantity;
            _context.CartItems.Update(existingCartItem);
            await _context.SaveChangesAsync();
            return existingCartItem;
        }


        public async Task<bool> DeleteCartItemAsync(int cartItemId)
        {
            var cartItem = await GetCartItemByIdAsync(cartItemId);
            if (cartItem == null)
            {
                return false;
            }

            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
