using Readify.Data;
using Readify.DTOs.Order;
using Readify.Entities;
using Readify.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Readify.Service
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateOrder(CreateOrderDto orderDto)
        {
            try
            {
                var order = new Order
                {
                    UserId = orderDto.UserId,
                    OrderDate = DateTime.UtcNow,
                    Status = OrderStatus.Pending, // Assuming enum exists
                    TotalAmount = orderDto.OrderItems.Sum(oi => oi.Quantity * oi.Price),
                    ShippingAddress = orderDto.ShippingAddress,
                    PaymentMethod = orderDto.PaymentMethod
                };

                _context.Orders.Add(order);
                _context.SaveChanges();

                foreach (var item in orderDto.OrderItems)
                {
                    var orderItem = new OrderItem
                    {
                        OrderId = order.OrderId,
                        BookId = item.BookId,
                        Quantity = item.Quantity,
                        Price = item.Price
                    };
                    _context.OrderItems.Add(orderItem);
                }

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating order: " + ex.Message);
            }
        }

        public OrderDto GetOrderById(int id)
        {
            try
            {
                var order = _context.Orders
                    .Include(o => o.OrderItems)
                    .FirstOrDefault(o => o.OrderId == id);

                if (order == null)
                    throw new Exception("Order not found");

                return new OrderDto
                {
                    OrderId = order.OrderId,
                    UserId = order.UserId,
                    OrderDate = order.OrderDate,
                    Status = order.Status,
                    TotalAmount = order.TotalAmount,
                    ShippingAddress = order.ShippingAddress,
                    PaymentMethod = order.PaymentMethod,
                    OrderItems = order.OrderItems.Select(oi => new OrderItemDto
                    {
                        BookId = oi.BookId,
                        Quantity = oi.Quantity,
                        Price = oi.Price
                    }).ToList()
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching order: " + ex.Message);
            }
        }

        public List<OrderSummaryDto> GetUserOrders(int userId)
        {
            try
            {
                return _context.Orders
                    .Where(o => o.UserId == userId)
                    .Select(o => new OrderSummaryDto
                    {
                        OrderId = o.OrderId,
                        OrderDate = o.OrderDate,
                        Status = o.Status,
                        TotalAmount = o.TotalAmount
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching user orders: " + ex.Message);
            }
        }

        public void UpdateOrderStatus(int id, UpdateOrderStatusDto statusDto)
        {
            try
            {
                var order = _context.Orders.Find(id);
                if (order == null)
                    throw new Exception("Order not found");

                order.Status = statusDto.Status;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating order status: " + ex.Message);
            }
        }
    }
}