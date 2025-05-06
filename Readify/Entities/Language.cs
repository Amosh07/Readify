using System.ComponentModel.DataAnnotations;

namespace Readify.Entities
{
    public class Language
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Name { get; set; }
    }
}
