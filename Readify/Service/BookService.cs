using Microsoft.EntityFrameworkCore;
using Readify.Data;
using Readify.DTOs.Book;
using Readify.Entities;
using Readify.Service.Interface;

namespace Readify.Service
{
    public class BookService : IBookService
    {
        private readonly ApplicationDbContext _context;

        public BookService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddBook(InsertBookDto bookDto)
        {
            try
            {
                var book = new Book
                {
                    ISBN = bookDto.ISBN,
                    Title = bookDto.Title,
                    AuthorId = bookDto.AuthorId,
                    PublisherId = bookDto.PublisherId,
                    CategoryId = bookDto.CategoryId,
                    LanguageId = bookDto.LanguageId,
                    ImageURL = bookDto.ImageUrl,
                    Format = bookDto.Format,
                    Description = bookDto.Description,
                    Price = bookDto.Price,
                    Stock = bookDto.Stock,
                    PublishDate = bookDto.PublishDate,
                    CreatedDate = DateTime.UtcNow,
                    TotalSold = bookDto.TotalSold
                };

                _context.Books.Add(book);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding book: " + ex.Message);
            }
        }

        public void DeleteBook(Guid id)
        {
            try
            {
                var book = _context.Books.FirstOrDefault(b => b.Id == id);
                if (book == null)
                    throw new Exception("Book not found");

                _context.Books.Remove(book);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting book: " + ex.Message);
            }
        }

        public List<GetAllBook> GetAllBooks()
        {
            try
            {
                var books = _context.Books.ToList();
                if (books == null || !books.Any())
                    throw new Exception("No books found");

                var result = new List<GetAllBook>();
                foreach (var b in books)
                {
                    result.Add(new GetAllBook
                    {
                        Id = b.Id,
                        ISBN = b.ISBN,
                        Title = b.Title,
                        AuthorId = b.AuthorId,
                        PublisherId = b.PublisherId,
                        CategoryId = b.CategoryId,
                        LanguageId = b.LanguageId,
                        ImageUrl = b.ImageURL,
                        Format = b.Format,
                        Description = b.Description,
                        Price = b.Price,
                        Stock = b.Stock,
                        TotalSold = b.TotalSold,
                        PublishDate = b.PublishDate,
                        CreatedDate = b.CreatedDate
                    });
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching books: " + ex.Message);
            }
        }


        public GetAllBook GetById(Guid id)
        {
            try
            {
                var book = _context.Books.FirstOrDefault(b => b.Id == id);
                if (book == null)
                    throw new Exception("Book not found");

                return new GetAllBook
                {
                    Id = book.Id,
                    ISBN = book.ISBN,
                    Title = book.Title,
                    AuthorId = book.AuthorId,
                    PublisherId = book.PublisherId,
                    CategoryId = book.CategoryId,
                    LanguageId = book.LanguageId,
                    ImageUrl= book.ImageURL,
                    Format = book.Format,
                    Description = book.Description,
                    Price = book.Price,
                    Stock = book.Stock,
                    TotalSold = book.TotalSold,
                    PublishDate = book.PublishDate,
                    CreatedDate = book.CreatedDate
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching book: " + ex.Message);
            }
        }

        public void UpdateBook(Guid id, UpdateBookDto bookDto)
        {
            try
            {
                var book = _context.Books.FirstOrDefault(b => b.Id == id);
                if (book == null)
                    throw new Exception("Book not found");

                book.ISBN = bookDto.ISBN;
                book.Title = bookDto.Title;
                book.AuthorId = bookDto.AuthorId;
                book.PublisherId = bookDto.PublisherId;
                book.CategoryId = bookDto.CategoryId;
                book.LanguageId = bookDto.LanguageId;
                book.ImageURL = bookDto.ImageUrl;
                book.Format = bookDto.Format;
                book.Description = bookDto.Description;
                book.Price = bookDto.Price;
                book.Stock = bookDto.Stock;
                book.PublishDate = bookDto.PublishDate;

                _context.Books.Update(book);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating book: " + ex.Message);
            }
        }

        public Task<IEnumerable<Book>> SearchBooksAsync(BookSearchFilterDto filters)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Book>> FilterBooksAsync(BookSearchFilterDto filters)
        {
            var query = _context.Books
                .Include(b => b.Reviews)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filters.Title))
                query = query.Where(b => b.Title.Contains(filters.Title));

            if (!string.IsNullOrWhiteSpace(filters.ISBN))
                query = query.Where(b => b.ISBN.Contains(filters.ISBN));

            if (!string.IsNullOrWhiteSpace(filters.Description))
                query = query.Where(b => b.Description.Contains(filters.Description));

            if (filters.AuthorId.HasValue)
                query = query.Where(b => b.AuthorId == filters.AuthorId);

            if (filters.CategoryId.HasValue)
                query = query.Where(b => b.CategoryId == filters.CategoryId);

            if (filters.PublisherId.HasValue)
                query = query.Where(b => b.PublisherId == filters.PublisherId);

            if (filters.LanguageId.HasValue)
                query = query.Where(b => b.LanguageId == filters.LanguageId);

            if (!string.IsNullOrWhiteSpace(filters.Format))
                query = query.Where(b => b.Format == filters.Format);

            if (filters.MinPrice.HasValue)
                query = query.Where(b => b.Price >= filters.MinPrice.Value);

            if (filters.MaxPrice.HasValue)
                query = query.Where(b => b.Price <= filters.MaxPrice.Value);

            if (filters.InStockOnly == true)
                query = query.Where(b => b.Stock > 0);

            if (filters.MinRating.HasValue)
                query = query.Where(b => b.Reviews.Any() &&
                    b.Reviews.Average(r => r.Rating) >= filters.MinRating.Value);

            return await query.ToListAsync();
        }
    }
}