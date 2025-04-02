using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceWeb.Domain;

namespace ECommerceWeb.Application.Interfaces
{
    public interface ICartRepository
    {
        Task<IEnumerable<CartItem>> GetCartItemsAsync(string userId);
        Task<CartItem> GetCartItemByIdAsync(int cartItemId);
        Task<CartItem> AddCartItemAsync(string userId, int quantity, int productId);
        //Task<CartItem> AddCartItemAsync(CartItem cartItem);
        Task<CartItem> UpdateCartItemAsync(int cartItemId, CartItem cartItem);
        Task<bool> DeleteCartItemAsync(int cartItemId);
    }
}
