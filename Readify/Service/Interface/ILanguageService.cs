using Readify.DTOs.Language;

namespace Readify.Service.Interface
{
    public interface ILanguageService
    {
        void AddLanguage(InsertLanguageDto languageDto);

        List<GetAllLanguage> GetAllLanguages();

        GetAllLanguage GetById(Guid id);

        void DeleteLanguage(Guid id);

        void UpdateLanguage(Guid id, UpdateLanguageDto languageDto);
    }
}
