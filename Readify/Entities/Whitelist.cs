using System;
using System.ComponentModel.DataAnnotations;

namespace Readify.Entities
{
    public class Whitelist
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid PersonId { get; set; } // FK to User
        public Guid BookId { get; set; }   // FK to Book

        public virtual User? User { get; set; }
        public virtual Book? Book { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
