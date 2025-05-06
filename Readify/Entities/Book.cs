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

        [ForeignKey(nameof(Author))]
        public Guid AuthorId { get; set; }

        [ForeignKey(nameof(Publisher))]
        public Guid PublisherId { get; set; }

        [ForeignKey(nameof(Category))]
        public Guid CategoryId { get; set; }

        [ForeignKey(nameof(Language))]
        public Guid LanguageId { get; set; }

        [ForeignKey(nameof(OrderItem))]
        public Guid OrderitemsId { get; set; }
        public virtual OrderItem? OrderItem { get; set; }

        [ForeignKey(nameof(Whitelist))]
        public Guid WhitelistId {  get; set; }

        public virtual Author? Author { get; set; }

        public virtual Publisher? Publisher { get; set; }

        public virtual Category? Category { get; set; }

        public virtual Language? Language { get; set; }

        public virtual Whitelist? Whitelist { get; set; }
    }
}
