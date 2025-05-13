using System;
using System.ComponentModel.DataAnnotations;

namespace Readify.Entities
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public decimal OrderAmount { get; set; }
        public decimal TotalDiscount { get; set; }
        public bool DiscountApplied { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public bool IsCancelled { get; set; }
        public string ClaimCode { get; set; }
        public DateTime ValidTill { get; set; }

        public string PersonId { get; set; } // FK to User

        public virtual ApplicationUser? User { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
