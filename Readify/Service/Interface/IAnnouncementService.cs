using Readify.DTOs.Announcement;

namespace Readify.Service.Interface
{
    public interface IAnnouncementService
    {
        void AddAnnouncement(InsertAnnouncementDto announcementDto);

        List<GetAllAnnouncement> GetAllAnnouncements();

        GetAllAnnouncement GetById(Guid id);

        void DeleteAnnouncement(Guid id);

        void UpdateAnnouncement(Guid id, UpdateAnnouncementDto announcementDto);
    }
}
