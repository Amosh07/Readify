﻿using System.ComponentModel.DataAnnotations;

namespace Readify.Entities
{
    public class Book
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Format { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int TotalSold { get; set; }
        public string? ImageURL { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime CreatedDate { get; set; }

        // Foreign Keys
        public Guid AuthorId { get; set; }
        public Guid PublisherId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid LanguageId { get; set; }
     

        // Navigation Properties
        public virtual Author Author { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual Category Category { get; set; }
        public virtual Language Language { get; set; }
        public virtual ICollection<Review>? Reviews { get; set; }

    }
}
