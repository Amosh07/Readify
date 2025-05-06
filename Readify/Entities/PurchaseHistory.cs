using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Readify.Entities
{
    public class PurchaseHistory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey(nameof(User))]
        public Guid PersonId { get; set; }

        [ForeignKey(nameof(Book))]
        public Guid BookId { get; set; }

        [ForeignKey(nameof(Review))]
        public Guid Review { get; set; }

        public virtual User? User { get; set; }

        public virtual Book? Book { get; set; }

        public virtual Review? Rating { get; set; }

        public string Comment { get; set; }

        public DateTime PurchaseDate { get; set; }
    }
}
