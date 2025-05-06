using System;

namespace Readify.Entities
{
    public class PurchaseHistory
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int? Rating { get; set; }
        public string Comment { get; set; }
        public DateTime PurchaseDate { get; set; }

        public User User { get; set; }
        public Book Book { get; set; }
    }
}
