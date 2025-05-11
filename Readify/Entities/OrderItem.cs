using System;
using System.ComponentModel.DataAnnotations;

namespace Readify.Entities
{
    public class OrderItem
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public int Qty { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }

        // FKs
        public Guid OrderId { get; set; }
        public Guid BookId { get; set; }

        // Navigation
        public virtual Order? Order { get; set; }
        public virtual Book? Book { get; set; }
    }
}
