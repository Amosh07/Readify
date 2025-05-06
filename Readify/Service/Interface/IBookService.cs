using Readify.DTOs.Book;

namespace Readify.Service.Interface
{
    public interface IBookService
    {
        void AddBook(InsertBookDto bookDto);

        List<GetAllBook> GetAllBooks();

        GetAllBook GetById(Guid id);

        void DeleteBook(Guid id);

        void UpdateBook(Guid id, UpdateBookDto bookDto);
    }
}
