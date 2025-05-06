using Readify.Data;
using Readify.DTOs.OrderItem;
using Readify.Entities;
using Readify.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Readify.Service
{
    public class OrderItemService : IOrderItemService
    {
        private readonly ApplicationDbContext _context;

        public void AddOrderItem(InsertOrderItemDto orderItemDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrderItem(int id)
        {
            throw new NotImplementedException();
        }

        public List<GetAllOrderItem> GetAllOrderItems()
        {
            throw new NotImplementedException();
        }

        public GetAllOrderItem GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrderItem(int id, UpdateOrderItemDto orderItemDto)
        {
            throw new NotImplementedException();
        }

        //    public OrderItemService(ApplicationDbContext context)
        //    {
        //        _context = context;
        //    }

        //    public void AddOrderItem(InsertOrderItemDto orderItemDto)
        //    {
        //        try
        //        {
        //            // Validate book exists and has sufficient stock
        //            var order = _context.Orders.Find(orderItemDto.OrderId);
        //            if (order == null)
        //                throw new Exception("Order not found");
        //            if (order.Stock < orderItemDto.Quantity)
        //                throw new Exception("Insufficient stock");

        //            var orderItem = new OrderItem
        //            {
        //                OrderId = orderItemDto.OrderId,
        //                BookId = orderItemDto.BookId,
        //                Quantity = orderItemDto.Quantity,
        //                Price = book.Price, // Use current book price
        //                CreatedDate = DateTime.UtcNow
        //            };

        //            // Update book stock
        //            book.Stock -= orderItemDto.Quantity;
        //            book.TotalSold += orderItemDto.Quantity;

        //            _context.OrderItems.Add(orderItem);
        //            _context.SaveChanges();
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception("Error adding order item: " + ex.Message);
        //        }
        //    }

        //    public void RemoveOrderItem(int orderItemId)
        //    {
        //        try
        //        {
        //            var orderItem = _context.OrderItems
        //                .Include(oi => oi.Book)
        //                .FirstOrDefault(oi => oi.OrderItemId == orderItemId);

        //            if (orderItem == null)
        //                throw new Exception("Order item not found");

        //            // Restore book stock
        //            orderItem.Book.Stock += orderItem.Quantity;
        //            orderItem.Book.TotalSold -= orderItem.Quantity;

        //            _context.OrderItems.Remove(orderItem);
        //            _context.SaveChanges();
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception("Error removing order item: " + ex.Message);
        //        }
        //    }

        //    public List<OrderItemDto> GetOrderItemsByOrder(int orderId)
        //    {
        //        try
        //        {
        //            return _context.OrderItems
        //                .Where(oi => oi.OrderId == orderId)
        //                .Select(oi => new OrderItemDto
        //                {
        //                    OrderItemId = oi.OrderItemId,
        //                    OrderId = oi.OrderId,
        //                    BookId = oi.BookId,
        //                    BookTitle = oi.Book.Title,
        //                    Quantity = oi.Quantity,
        //                    Price = oi.Price,
        //                    CreatedDate = oi.CreatedDate
        //                })
        //                .ToList();
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception("Error fetching order items: " + ex.Message);
        //        }
        //    }

        //    public void UpdateOrderItemQuantity(int orderItemId, UpdateOrderItemDto updateDto)
        //    {
        //        try
        //        {
        //            var orderItem = _context.OrderItems
        //                .Include(oi => oi.Book)
        //                .FirstOrDefault(oi => oi.OrderItemId == orderItemId);

        //            if (orderItem == null)
        //                throw new Exception("Order item not found");

        //            // Calculate stock difference
        //            int quantityDifference = updateDto.Quantity - orderItem.Quantity;
        //            if (orderItem.Book.Stock < quantityDifference)
        //                throw new Exception("Insufficient stock for quantity update");

        //            // Update stock
        //            orderItem.Book.Stock -= quantityDifference;
        //            orderItem.Book.TotalSold += quantityDifference;

        //            // Update order item
        //            orderItem.Quantity = updateDto.Quantity;
        //            _context.SaveChanges();
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception("Error updating order item: " + ex.Message);
        //        }
        //    }

        //    public void AddOrderItem(InsertOrderItemDto orderItemDto)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public List<GetAllOrderItem> GetAllOrderItems()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public GetAllOrderItem GetById(int id)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public void DeleteOrderItem(int id)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public void UpdateOrderItem(int id, UpdateOrderItemDto orderItemDto)
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
    }

}