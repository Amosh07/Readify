using Readify.Data;
using Readify.DTOs.Author;
using Readify.Entities;
using Readify.Service.Interface;

namespace Readify.Service
{
    public class AuthorService : IAuthorService
    {
        private readonly ApplicationDbContext _context;

        public AuthorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddAuthor(InsertAuthorDto authorDto)
        {
            try
            {
                var author = new Author
                {
                    Name = authorDto.Name
                };

                _context.Authors.Add(author);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding author: " + ex.Message);
            }
        }

        public void DeleteAuthor(Guid id)
        {
            try
            {
                var author = _context.Authors.FirstOrDefault(a => a.Id == id);
                if (author == null)
                    throw new Exception("Author not found");

                _context.Authors.Remove(author);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting author: " + ex.Message);
            }
        }

        public List<GetAllAuthor> GetAllAuthors()
        {
            try
            {
                var author = _context.Authors.ToList();
                if (author == null)
                    throw new Exception("No active author found");

                var result = new List<GetAllAuthor>();
                foreach (var a in author)
                {
                    result.Add(new GetAllAuthor
                    {
                        Id = a.Id,
                        Name = a.Name,
                        isActive = a.isActive

                    });
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching authors: " + ex.Message);
            }
        }

        public GetAllAuthor GetById(Guid id)
        {
            var author = _context.Authors.FirstOrDefault(u => u.Id == id);

            if (author == null)
                throw new Exception("No active users found");

            var result = new GetAllAuthor()
            {
                Id = author.Id,
                Name = author.Name,
                isActive = author.isActive
            };

            return result;
        }

        public void UpdateAuthor(Guid id, UpdateAuthorDto authorDto)
        {
            try
            {
                var author = _context.Authors.FirstOrDefault(a => a.Id == id);
                if (author == null)
                    throw new Exception("Author not found");

                author.Name = authorDto.Name;
                _context.Authors.Update(author);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating author: " + ex.Message);
            }
        }
    }
}