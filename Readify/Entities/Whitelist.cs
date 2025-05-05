using System;

namespace Readify.Entities
{
    public class Whitelist
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime CreatedDate { get; set; }

        public User User { get; set; }
        public Book Book { get; set; }
    }
}
