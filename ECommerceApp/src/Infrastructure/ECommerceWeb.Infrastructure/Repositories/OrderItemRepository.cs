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
    public class OrderItemRepository : IOrderItemRepository
    {
        readonly ApplicationDbContext _context;

        public OrderItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderItem>> GetOrderItemsAsync(int orderId)
        {
            return await _context.OrderItems
                .Include(oi => oi.Product)
                .Where(oi => oi.OrderId == orderId)
                .ToListAsync();
        }

        public async Task<OrderItem> GetOrderItemByIdAsync(int orderItemId)
        {
            return await _context.OrderItems
                .Include(oi => oi.Product)
                .FirstOrDefaultAsync(oi => oi.OrderItemId == orderItemId);
        }

        public async Task<OrderItem> AddOrderItemAsync(OrderItem orderItem)
        {
            await _context.OrderItems.AddAsync(orderItem);
            await _context.SaveChangesAsync();
            return orderItem;
        }

        public async Task<OrderItem> UpdateOrderItemAsync(int orderItemId, OrderItem orderItem)
        {
            var existingOrderItem = await GetOrderItemByIdAsync(orderItemId);
            if (existingOrderItem == null)
            {
                throw new ArgumentException("Order item not found");
            }

            existingOrderItem.Quantity = orderItem.Quantity;
            _context.OrderItems.Update(existingOrderItem);
            await _context.SaveChangesAsync();
            return existingOrderItem;
        }

        public async Task<bool> DeleteOrderItemAsync(int orderItemId)
        {
            var orderItem = await GetOrderItemByIdAsync(orderItemId);
            if (orderItem == null)
            {
                return false;
            }
            _context.OrderItems.Remove(orderItem);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
