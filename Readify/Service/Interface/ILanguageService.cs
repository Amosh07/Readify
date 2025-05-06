using Readify.DTOs.Language;
using System.Collections.Generic;

namespace Readify.Service.Interface
{
    public interface ILanguageService
    {
        void AddLanguage(InsertLanguageDto languageDto);

        List<GetAllLanguage> GetAllLanguages();

        GetAllLanguage GetById(int id);

        void DeleteLanguage(int id);

        void UpdateLanguage(int id, UpdateLanguageDto languageDto);
    }
}
