using System;

namespace Readify.Entities
{
    public class OrderItem
    {
        public int OrderId { get; set; }
        public int BookId { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }

        public Order Order { get; set; }
        public Book Book { get; set; }
    }
}
