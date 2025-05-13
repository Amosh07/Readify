namespace Readify.DTOs.Book
{
    public class BookSearchFilterDto
    {
        public string? Title { get; set; }
        public string? ISBN { get; set; }
        public string? Description { get; set; }

        public Guid? AuthorId { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? PublisherId { get; set; }
        public Guid? LanguageId { get; set; }

        public string? Format { get; set; }

        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }

        public int? MinRating { get; set; }
        public bool? InStockOnly { get; set; }
    }
}
