using Readify.Entities;

namespace Readify.DTOs.Book
{
    public class UpdateBookDto
    {

        public int BookId { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        public int CategoryId { get; set; }
        public int LanguageId { get; set; }
        public string Format { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int TotalSold { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
