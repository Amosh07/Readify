using Readify.DTOs.OrderItem;
using System.Collections.Generic;

namespace Readify.Service.Interface
{
    public interface IOrderItemService
    {
        void AddOrderItem(InsertOrderItemDto orderItemDto);

        List<GetAllOrderItem> GetAllOrderItems();

        GetAllOrderItem GetById(int id);

        void DeleteOrderItem(int id);

        void UpdateOrderItem(int id, UpdateOrderItemDto orderItemDto);
    }
}
