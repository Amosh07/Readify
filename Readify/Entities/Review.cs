using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Readify.Entities
{
    public class Review 
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey(nameof(User))]
        public Guid PersonId { get; set; }

        [ForeignKey(nameof(Book))]
        public Guid BookId { get; set; }

        public virtual User? User { get; set; }

        public virtual Book? Book { get; set; }

        public int rating {  get; set; }

        public DateTime ReviewDate { get; set; }

    }
}
