namespace Readify.DTOs.Announcement
{
    public class UpdateAnnouncementDto
    {
        public Guid Id { get; set; }
        public string AnnouncementTitle { get; set; }
        public string AnnouncementContent { get; set; }
    }
}
