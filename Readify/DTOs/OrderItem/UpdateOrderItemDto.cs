namespace Readify.DTOs.OrderItem
{
    public class UpdateOrderItemDto
    {
        public Guid Id { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid OrderId { get; set; }
        public Guid BookId { get; set; }
    }
}
