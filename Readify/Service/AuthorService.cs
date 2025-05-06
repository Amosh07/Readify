using Readify.Data;
using Readify.DTOs.Author;
using Readify.DTOs.User;
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

        public void DeleteAuthor(int id)
        {
            try
            {
                var author = _context.Authors.FirstOrDefault(a => a.AuthorId == id);
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
                var authors = _context.Authors.ToList();
                if (authors == null || !authors.Any())
                    throw new Exception("No authors found");

                return authors.Select(a => new GetAllAuthor
                {
                    AuthorId = a.AuthorId,
                    Name = a.Name
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching authors: " + ex.Message);
            }
        }

        public GetAllAuthor GetAuthorById(int id)
        {
            try
            {
                var author = _context.Authors.FirstOrDefault(a => a.AuthorId == id);
                if (author == null)
                    throw new Exception("Author not found");

                return new GetAllAuthor
                {
                    AuthorId = author.AuthorId,
                    Name = author.Name
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching author: " + ex.Message);
            }
        }

        public GetAllAuthor GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateAuthor(int id, UpdateAuthorDto authorDto)
        {
            try
            {
                var author = _context.Authors.FirstOrDefault(a => a.AuthorId == id);
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

        List<GetAllAuthor> IAuthorService.GetAllAuthors()
        {
            throw new NotImplementedException();
        }
    }
}