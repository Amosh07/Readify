namespace Readify.DTOs.PurchaseHistory
{
    public class InsertPurchaseHistoryDto
    {

        public Guid UserId { get; set; }

        public Guid BookId { get; set; }

        public Guid Review { get; set; }

        public string Comment { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
