namespace Readify.DTOs.CartItem
{
    public class GetAllCartItem
    {
        public Guid Id { get; set; }
        public int Qty { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid BookId { get; set; }
        public string PersonId { get; set; }

    }
}
