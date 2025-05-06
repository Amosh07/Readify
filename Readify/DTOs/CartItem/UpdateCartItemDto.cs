namespace Readify.DTOs.CartItem
{
    public class UpdateCartItemDto
    {
        public Guid Id { get; set; }
        public int Qty { get; set; }
        public DateTime CreatedDate { get; set; }

        public Guid BookId { get; set; }
        public Guid PersonId { get; set; }

    }
}
