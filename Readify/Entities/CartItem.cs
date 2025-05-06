using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Readify.Entities
{
    public class CartItem
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public int Qty { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey(nameof(User))]
        public Guid PersonId { get; set; }

        [ForeignKey(nameof(Book))]
        public Guid BookId { get; set; }

        public virtual User? User { get; set; }

        public virtual Book? Book { get; set; }
    }
}
