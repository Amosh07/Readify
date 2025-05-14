using Microsoft.EntityFrameworkCore;
using Readify.Data;
using Readify.DTOs.Announcement;
using Readify.DTOs.Author;
using Readify.Entities;
using Readify.Service.Interface;

namespace Readify.Service
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly ApplicationDbContext _context;
        public void AddAnnouncement(InsertAnnouncementDto announcementDto)
        {
            try
            {
                var announcement = new Announcement
                {
                    AnnouncementTitle = announcementDto.AnnouncementTitle,
                    AnnouncementContent = announcementDto.AnnouncementContent,
                };

                _context.Announcements.Add(announcement);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding announcement: " + ex.Message);
            }
        }

        public void DeleteAnnouncement(Guid id)
        {
            try
            {
                var announcement = _context.Announcements.FirstOrDefault(a => a.Id == id);
                if (announcement == null)
                    throw new Exception("Announcement not found");

                _context.Announcements.Remove(announcement);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting announcement: " + ex.Message);
            }
        }

        public List<GetAllAnnouncement> GetAllAnnouncements()
        {
            try
            {
                var announcements = _context.Announcements.ToList();
                if (announcements == null || !announcements.Any())
                    throw new Exception("No announcements found");

                return announcements.Select(a => new GetAllAnnouncement
                {
                    AnnouncementTitle = a.AnnouncementTitle,
                    AnnouncementContent = a.AnnouncementContent,
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching announcement: " + ex.Message);
            }
        }

        public GetAllAnnouncement GetById(Guid id)
        {
            try
            {
                var announcement = _context.Announcements.FirstOrDefault(a => a.Id == id);
                if (announcement == null)
                    throw new Exception("Announcement not found");

                return new GetAllAnnouncement
                {

                    AnnouncementTitle = announcement.AnnouncementTitle,
                    AnnouncementContent = announcement.AnnouncementContent,
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching announcement: " + ex.Message);
            }
        }

        public void UpdateAnnouncement(Guid id, UpdateAnnouncementDto announcementDto)
        {
            try
            {
                var announcement = _context.Announcements.FirstOrDefault(a => a.Id == id);
                if (announcement == null)
                    throw new Exception("Announcement not found");

                announcement.AnnouncementTitle = announcementDto.AnnouncementTitle;
                announcement.AnnouncementContent = announcementDto.AnnouncementContent;
                _context.Announcements.Update(announcement);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating announcement: " + ex.Message);
            }
        }
    }
}
