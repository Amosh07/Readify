using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public DateTime PublishDate { get; set; }
        public DateTime CreatedDate { get; set; }

        // Foreign Keys
        public Guid AuthorId { get; set; }
        public Guid PublisherId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid LanguageId { get; set; }
        //public Guid WhitelistId { get; set; }
        //public Guid OrderItemId { get; set; }

        // Navigation Properties
        public virtual Author Author { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual Category Category { get; set; }
        public virtual Language Language { get; set; }
        //public virtual Whitelist Whitelist { get; set; }

        // A book can be in multiple order items
        //public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
