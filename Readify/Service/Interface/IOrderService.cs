using Readify.DTOs.Order;
using Readify.Entities;

namespace Readify.Service.Interface
{
    public interface IOrderService
    {
        void AddOrder(InsertOrderDto orderDto);

        List<GetAllOrder> GetAllOrders();

        GetAllOrder GetById(Guid id);

        void DeleteOrder(Guid id);

        void UpdateOrder(Guid id, UpdateOrderDto orderDto);

        Task<IEnumerable<Order>> FilterOrdersAsync(OrderSearchFilterDto filters);
    }
}
