using System;

namespace Readify.Entities
{
    public class CartItem
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int Qty { get; set; }
        public DateTime CreatedDate { get; set; }

        public User User { get; set; }
        public Book Book { get; set; }
    }
}
