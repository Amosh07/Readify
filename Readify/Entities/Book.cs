using System;
using System.Collections.Generic;

namespace Readify.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        public int CategoryId { get; set; }
        public int LanguageId { get; set; }
        public string Format { get; set; } // e.g., Hardcover, Deluxe
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int TotalSold { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public Author Author { get; set; }
        public Publisher Publisher { get; set; }
        public Category Category { get; set; }
        public Language Language { get; set; }

        public List<OrderItem> OrderItems { get; set; }
        public List<Whitelist> Whitelists { get; set; }
    }
}
