using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Readify.Entities
{
    public class Announcement
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string AnnouncementTitle { get; set; }
        public string AnnouncementContent { get; set; }
    }
}
