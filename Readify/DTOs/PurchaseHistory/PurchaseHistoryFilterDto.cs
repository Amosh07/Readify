namespace Readify.DTOs.PurchaseHistory
{
    public class PurchaseHistoryFilterDto
    {
        public Guid? PersonId { get; set; }
        public Guid? BookId { get; set; }
        public Guid? ReviewId { get; set; }
        public DateTime? StartDate { get; set; } // for PurchaseDate
        public DateTime? EndDate { get; set; }
        public string? CommentKeyword { get; set; }
    }
}
