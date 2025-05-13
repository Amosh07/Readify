namespace Readify.DTOs.CartItem
{
    public class CartItemSearchFilterDto
    {
        public Guid? PersonId { get; set; }
        public Guid? BookId { get; set; }
        public int? MinQty { get; set; }
        public int? MaxQty { get; set; }
        public DateTime? CreatedAfter { get; set; }
        public DateTime? CreatedBefore { get; set; }
    }
}
