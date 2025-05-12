using Readify.DTOs.Author;
using Readify.Entities;

namespace Readify.Service.Interface
{
    public interface IAuthorService
    {
        void AddAuthor(InsertAuthorDto authorDto);

        List<GetAllAuthor> GetAllAuthors();

        GetAllAuthor GetById(Guid id);

        void DeleteAuthor(Guid id);

        void UpdateAuthor(Guid id, UpdateAuthorDto authorDto);

        Task<IEnumerable<Author>> FilterAuthorsAsync(AuthorSearchFilterDto filters);
    }
}
