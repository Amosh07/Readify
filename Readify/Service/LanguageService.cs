using Readify.Data;
using Readify.DTOs.Language;
using Readify.Entities;
using Readify.Service.Interface;

namespace Readify.Service
{
    public class LanguageService : ILanguageService
    {
        private readonly ApplicationDbContext _context;

        public LanguageService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddLanguage(InsertLanguageDto languageDto)
        {
            try
            {
                var language = new Language
                {
                    Name = languageDto.Name,
                };

                _context.Languages.Add(language);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding language: " + ex.Message);
            }
        }

        public void DeleteLanguage(Guid id)
        {
            try
            {
                var language = _context.Languages.FirstOrDefault(b => b.Id == id);
                if (language == null)
                    throw new Exception("language not found");

                _context.Languages.Remove(language);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting language: " + ex.Message);
            }
        }

        public List<GetAllLanguage> GetAllLanguages()
        {
            try
            {
                var languages = _context.Languages.ToList();
                if (languages == null || !languages.Any())
                    throw new Exception("No category found");

                var result = new List<GetAllLanguage>();
                foreach (var b in languages)
                {
                    result.Add(new GetAllLanguage
                    {
                        Id = b.Id,
                        Name = b.Name,
                    });
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching language: " + ex.Message);
            }
        }

        public GetAllLanguage GetById(Guid id)
        {
            try
            {
                var language = _context.Languages.FirstOrDefault(b => b.Id == id);
                if (language == null)
                    throw new Exception("Language not found");

                return new GetAllLanguage
                {
                    Id = language.Id,
                    Name = language.Name,
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching language: " + ex.Message);
            }
        }

        public void UpdateLanguage(Guid id, UpdateLanguageDto languageDto)
        {
            try
            {
                var language = _context.Languages.FirstOrDefault(b => b.Id == id);
                if (language == null)
                    throw new Exception("Language not found");

                language.Id = languageDto.Id;
                language.Name = languageDto.Name;

                _context.Languages.Update(language);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating language: " + ex.Message);
            }
        }
        List<GetAllLanguage> ILanguageService.GetAllLanguages()
        {
            throw new NotImplementedException();
        }
    }
}
