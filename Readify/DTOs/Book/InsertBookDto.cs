namespace Readify.DTOs.Book
{
    public class InsertBookDto
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public Guid AuthorId { get; set; }
        public Guid PublisherId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid LanguageId { get; set; }
    
        public string Format { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int TotalSold { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
