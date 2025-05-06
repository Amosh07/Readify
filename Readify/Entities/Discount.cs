using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Readify.Entities
{
    public class Discount
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public int DiscountPercentage { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool isOnSale { get; set; }

        [ForeignKey(nameof(Book))]

        public Guid BookId { get; set; }

        public virtual Book? Book { get; set; }

    }
}
