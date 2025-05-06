using Readify.Data;
using Readify.DTOs.Book;
using Readify.DTOs.Order;
using Readify.Entities;
using Readify.Service.Interface;


namespace Readify.Service
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddOrder(InsertOrderDto orderDto)
        {
            try
            {
                var order = new Order
                {
                    OrderId = orderDto.OrderId,
                    OrderAmount = orderDto.OrderAmount,
                    TotalDiscount = orderDto.TotalDiscount,
                    DiscountApplied = orderDto.DiscountApplied,
                    OrderDate = orderDto.OrderDate,
                    Status = orderDto.Status,
                    IsCancelled = orderDto.IsCancelled,
                    ClaimCode = orderDto.ClaimCode,
                    ValidTill = orderDto.ValidTill,

                };

                _context.Orders.Add(order);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding order: " + ex.Message);
            }
        }

        public void CreateOrder(CreateOrderDto orderDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrder(int id)
        {
            try
            {
                var order = _context.Orders.FirstOrDefault(o => o.OrderId == id);
                if (order == null)
                    throw new Exception("Book not found");

                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting order: " + ex.Message);
            }
        }

        public List<GetAllOrder> GetAllOrders()
        {
            try
            {
                var orders = _context.Orders.ToList();
                if (orders == null || !orders.Any())
                    throw new Exception("No orders found");

                var result = new List<GetAllOrder>();
                foreach (var o in orders)
                {
                    result.Add(new GetAllOrder
                    {
                        OrderId = o.OrderId,
                        OrderAmount = o.OrderAmount,
                        TotalDiscount = o.TotalDiscount,
                        DiscountApplied = o.DiscountApplied,
                        OrderDate = o.OrderDate,
                        Status = o.Status,
                        IsCancelled = o.IsCancelled,
                        ClaimCode = o.ClaimCode,
                        ValidTill = o.ValidTill
                    });
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching orders: " + ex.Message);
            }
        }

        public GetAllOrder GetById(int id)
        {
            try
            {
                var order = _context.Orders.FirstOrDefault(o => o.OrderId == id);
                if (order == null)
                    throw new Exception("Order not found");

                return new GetAllOrder
                {
                    OrderId = order.OrderId,
                    OrderAmount = order.OrderAmount,
                    TotalDiscount = order.TotalDiscount,
                    DiscountApplied = order.DiscountApplied,
                    OrderDate = order.OrderDate,
                    Status = order.Status,
                    ClaimCode = order.ClaimCode,
                    ValidTill = order.ValidTill

                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching order: " + ex.Message);
            }
        }

        public GetAllOrder GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(int id, UpdateOrderDto orderDto)
        {
            try
            {
                var order = _context.Orders.FirstOrDefault(o => o.OrderId == id);
                if (order== null)
                    throw new Exception("Order not found");

                order.OrderId = orderDto.OrderId;
                order.OrderAmount = orderDto.OrderAmount;
                order.TotalDiscount = orderDto.TotalDiscount;
                order.DiscountApplied = orderDto.DiscountApplied;
                order.OrderDate = orderDto.OrderDate;
                order.Status = orderDto.Status;
                order.IsCancelled = orderDto.IsCancelled;
                order.ClaimCode = orderDto.ClaimCode;
                order.ValidTill = orderDto.ValidTill;

                _context.Orders.Update(order);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating order: " + ex.Message);
            }
        }

        public void UpdateOrder(Guid id, UpdateOrderDto orderDto)
        {
            throw new NotImplementedException();
        }
    }

}