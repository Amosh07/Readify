using System.ComponentModel.DataAnnotations.Schema;

namespace Readify.DTOs.OrderItem
{
    public class InsertOrderItemDto
    {
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid OrderId { get; set; }
        public Guid BookId { get; set; }
    }
}
