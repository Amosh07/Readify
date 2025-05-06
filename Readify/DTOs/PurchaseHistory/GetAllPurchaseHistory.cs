namespace Readify.DTOs.PurchaseHistory
{
    public class GetAllPurchaseHistory
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public Guid BookId { get; set; }

        public Guid Review { get; set; }

        public string Comment { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
