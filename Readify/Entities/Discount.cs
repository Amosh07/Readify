using System;
using System.ComponentModel.DataAnnotations;

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

        public Guid BookId { get; set; } // FK to Book

        public virtual Book? Book { get; set; } // Navigation property
    }
}
