using System;
using System.ComponentModel.DataAnnotations;

namespace Readify.Entities
{
    public class CartItem
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public int Qty { get; set; }
        public DateTime CreatedDate { get; set; }

        public String PersonId { get; set; } // Foreign key to User
        public Guid BookId { get; set; }   // Foreign key to Book

        public virtual ApplicationUser? User { get; set; }
        public virtual Book? Book { get; set; }
    }
}
