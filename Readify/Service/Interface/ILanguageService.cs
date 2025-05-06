using Readify.DTOs.Language;
using System.Collections.Generic;

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
