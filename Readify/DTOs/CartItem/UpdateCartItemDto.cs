namespace Readify.DTOs.CartItem
{
    public class UpdateCartItemDto
    {
        public Guid Id { get; set; }
        public int Qty { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
