namespace Readify.DTOs.Review
{
    public class UpdateReviewDto
    {
        public Guid Id { get; set; }

        public string PersonId { get; set; } // FK to User
        public Guid BookId { get; set; }   // FK to Book

        public int Rating { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}
