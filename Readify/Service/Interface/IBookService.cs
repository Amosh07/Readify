using Readify.DTOs.Book;
using System;
using System.Collections.Generic;

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
