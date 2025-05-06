using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [ForeignKey(nameof(User))]
        public Guid PersonId { get; set; }

        public virtual User? User { get; set; }
    }
}
