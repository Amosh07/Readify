using Readify.Data;
using Readify.DTOs.OrderItem;
using Readify.Service.Interface;

namespace Readify.Service
{
    public class OrderItemService : IOrderItemService
    {
        private readonly ApplicationDbContext _context;

        public void AddOrderItem(InsertOrderItemDto orderItemDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrderItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<GetAllOrderItem> GetAllOrderItems()
        {
            throw new NotImplementedException();
        }

        public GetAllOrderItem GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrderItem(Guid id, UpdateOrderItemDto orderItemDto)
        {
            throw new NotImplementedException();
        }
    }

}