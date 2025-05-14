namespace Readify.DTOs.Review
{
    public class InsertReviewDto
    {
        public string PersonId { get; set; } // FK to User
        public Guid BookId { get; set; }   // FK to Book

        public int Rating { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}
