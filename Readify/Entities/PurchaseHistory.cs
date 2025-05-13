using System;
using System.ComponentModel.DataAnnotations;

namespace Readify.Entities
{
    public class PurchaseHistory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string PersonId { get; set; } // FK to User
        public Guid BookId { get; set; }   // FK to Book
        public Guid ReviewId { get; set; } // FK to Review

        public virtual ApplicationUser? User { get; set; }
        public virtual Book? Book { get; set; }
        public virtual Review? Rating { get; set; }

        public string Comment { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
