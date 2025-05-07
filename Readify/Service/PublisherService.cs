using Readify.Data;
using Readify.DTOs.Publisher;
using Readify.Entities;
using Readify.Service.Interface;

namespace Readify.Service
{
    public class PublisherService : IPublisherService
    {
        private readonly ApplicationDbContext _context;

        public PublisherService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddPublisher(InsertPublisherDto publisherDto)
        {
            try
            {
                var publisher = new Publisher
                {
                    Name = publisherDto.Name
                };
                _context.Publishers.Add(publisher);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding publisher: " + ex.Message);
            }
        }

        public void DeletePublisher(Guid id)
        {
            try
            {
                var publisher = _context.Publishers.FirstOrDefault(p => p.Id == id);
                if (publisher == null)
                    throw new Exception("Publisher not found");
                _context.Publishers.Remove(publisher);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting publisher: " + ex.Message);
            }
        }

        public List<GetAllPublisher> GetAllPublishers()
        {
            try
            {
                var publishers = _context.Publishers.ToList();
                var publisherDto = new List<GetAllPublisher>();
                foreach (var p in publishers)
                {
                    publisherDto.Add(new GetAllPublisher
                    {
                        Id = p.Id,
                        Name = p.Name
                    });
                }
                return publisherDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving publishers: " + ex.Message);
            }
        }

        public GetAllPublisher GetById(Guid id)
        {
            try
            {
                var publisher = _context.Publishers.FirstOrDefault(p => p.Id == id);
                if (publisher == null)
                    throw new Exception("Publisher not found");
                return new GetAllPublisher
                {
                    Id = publisher.Id,
                    Name = publisher.Name
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving publisher: " + ex.Message);
            }
        }

        public void UpdatePublisher(Guid id, UpdatePublisherDto publisherDto)
        {
            try
            {
                var publisher = _context.Publishers.FirstOrDefault(p => p.Id == id);
                if (publisher == null)
                    throw new Exception("Publisher not found");
                publisher.Name = publisherDto.Name;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating publisher: " + ex.Message);
            }
        }
    }
}
