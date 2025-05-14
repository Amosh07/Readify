using System.ComponentModel.DataAnnotations;

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
