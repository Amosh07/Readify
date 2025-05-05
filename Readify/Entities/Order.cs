using System;

namespace Readify.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public decimal OrderAmount { get; set; }
        public decimal TotalDiscount { get; set; }
        public bool DiscountApplied { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public bool IsCancelled { get; set; }
        public string ClaimCode { get; set; }
        public DateTime ValidTill { get; set; }

        public User User { get; set; }
    }
}
