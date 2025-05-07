using Readify.DTOs.OrderItem;

namespace Readify.Service.Interface
{
    public interface IOrderItemService
    {
        void AddOrderItem(InsertOrderItemDto orderItemDto);

        List<GetAllOrderItem> GetAllOrderItems();

        GetAllOrderItem GetById(Guid id);

        void DeleteOrderItem(Guid id);

        void UpdateOrderItem(Guid id, UpdateOrderItemDto orderItemDto);
    }
}
