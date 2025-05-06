using System.ComponentModel.DataAnnotations;

namespace Readify.Entities
{
    public class Author
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Name { get; set; }

        public bool isActive { get; set; }
    }
}
