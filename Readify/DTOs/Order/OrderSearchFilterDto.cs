namespace Readify.DTOs.Order
{
    public class OrderSearchFilterDto
    {
        public Guid? PersonId { get; set; }
        public bool? DiscountApplied { get; set; }
        public bool? IsCancelled { get; set; }
        public string? Status { get; set; }
        public DateTime? FromOrderDate { get; set; }
        public DateTime? ToOrderDate { get; set; }
        public decimal? MinAmount { get; set; }
        public decimal? MaxAmount { get; set; }
        public string? ClaimCode { get; set; }
    }
}
