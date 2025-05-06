namespace Readify.DTOs.WhiteList
{
    public class UpdateWhiteListDto
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid BookId { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
