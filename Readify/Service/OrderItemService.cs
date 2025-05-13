using Readify.Data;
using Readify.DTOs.OrderItem;
using Readify.Entities;
using Readify.Service.Interface;

namespace Readify.Service
{
    public class OrderItemService : IOrderItemService
    {
        private readonly ApplicationDbContext _context;

        public OrderItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddOrderItem(InsertOrderItemDto orderItemDto)
        {
            try
            {
                var orderItem = new OrderItem
                {
                    Qty = orderItemDto.Qty,
                    Price = orderItemDto.Price,
                    CreatedDate = orderItemDto.CreatedDate,
                    OrderId = orderItemDto.OrderId,
                    BookId = orderItemDto.BookId,

                };
                _context.OrderItems.Add(orderItem);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding order item: " + ex.Message);
            }
        }

        public void DeleteOrderItem(Guid id)
        {
            try
            {
                var orderItem = _context.OrderItems.FirstOrDefault(o => o.Id == id);
                if (orderItem == null)
                    throw new Exception("Order item not found");
                _context.OrderItems.Remove(orderItem);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting order item: " + ex.Message);
            }
        }

        public List<GetAllOrderItem> GetAllOrderItems()
        {
            try
            {
                var orderItems = _context.OrderItems.ToList();
                if (orderItems == null || !orderItems.Any())
                    throw new Exception("No order items found");
                var result = new List<GetAllOrderItem>();
                foreach (var o in orderItems)
                {
                    result.Add(new GetAllOrderItem
                    {
                        Id = o.Id,
                        Qty = o.Qty,
                        Price = o.Price,
                        CreatedDate = o.CreatedDate,
                        OrderId = o.OrderId,
                        BookId = o.BookId,
                    });
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving order items: " + ex.Message);
            }
        }

        public GetAllOrderItem GetById(Guid id)
        {
            try
            {
                var orderItem = _context.OrderItems.FirstOrDefault(o => o.Id == id);
                if (orderItem == null)
                    throw new Exception("Order item not found");
                return new GetAllOrderItem
                {
                    Id = orderItem.Id,
                    Qty = orderItem.Qty,
                    Price = orderItem.Price,
                    CreatedDate = orderItem.CreatedDate,
                    OrderId = orderItem.OrderId,
                    BookId = orderItem.BookId,
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving order item: " + ex.Message);
            }
        }

        public void UpdateOrderItem(Guid id, UpdateOrderItemDto orderItemDto)
        {
            try
            {
                var orderItem = _context.OrderItems.FirstOrDefault(o => o.Id == id);
                if (orderItem == null)
                    throw new Exception("Order item not found");
                orderItem.Qty = orderItemDto.Qty;
                orderItem.Price = orderItemDto.Price;
                orderItem.CreatedDate = orderItemDto.CreatedDate;
                orderItem.OrderId = orderItemDto.OrderId;
                orderItem.BookId = orderItemDto.BookId;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating order item: " + ex.Message);
            }
        }
    }

}