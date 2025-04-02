using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceWeb.Domain;

namespace ECommerceWeb.Application.Interfaces
{
    public interface IOrderItemRepository
    {
        Task<IEnumerable<OrderItem>> GetOrderItemsAsync(int orderId);
        Task<OrderItem> GetOrderItemByIdAsync(int orderItemId);
        Task<OrderItem> AddOrderItemAsync(OrderItem orderItem);
        Task<OrderItem> UpdateOrderItemAsync(int orderItemId, OrderItem orderItem);
        Task<bool> DeleteOrderItemAsync(int orderItemId);
    }
}
