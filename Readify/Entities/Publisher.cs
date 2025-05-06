using System.ComponentModel.DataAnnotations;

namespace Readify.Entities
{
    public class Publisher
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; }
    }
}
