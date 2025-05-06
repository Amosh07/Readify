using Readify.DTOs.Book;

namespace Readify.Service.Interface
{
    public interface IBookService
    {
        void AddBook(InsertBookDto bookDto);

        List<GetAllBook> GetAllBooks();

        GetAllBook GetById(int id);

        void DeleteBook(int id);

        void UpdateBook(int id, UpdateBookDto bookDto);
    }
}
