using System.ComponentModel.DataAnnotations;

namespace Readify.DTOs.Announcement
{
    public class GetAllAnnouncement
    {
        public Guid Id { get; set; }
        public string AnnouncementTitle { get; set; }
        public string AnnouncementContent { get; set; }
    }
}
