using Readify.DTOs.Author;
using System;
using System.Collections.Generic;

namespace Readify.Service.Interface
{
    public interface IAuthorService
    {
        void AddAuthor(InsertAuthorDto authorDto);

        List<GetAllAuthor> GetAllAuthors();

        GetAllAuthor GetById(int id);

        void DeleteAuthor(int id);

        void UpdateAuthor(int id, UpdateAuthorDto authorDto);
    }
}
