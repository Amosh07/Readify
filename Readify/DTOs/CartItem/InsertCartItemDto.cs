namespace Readify.DTOs.CartItem
{
    public class InsertCartItemDto
    {
        public int Qty { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid BookId { get; set; }
        public string PersonId { get; set; }
    }
}
