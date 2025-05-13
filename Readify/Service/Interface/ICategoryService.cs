using Readify.DTOs.Category;
using Readify.Entities;

namespace Readify.Service.Interface
{
    public interface ICategoryService
    {
        void AddCategory(InsertCategoryDto categoryDto);

        List<GetAllCategory> GetAllCategories();

        GetAllCategory GetById(Guid id);

        void DeleteCategory(Guid id);

        void UpdateCategory(Guid id, UpdateCategoryDto categoryDto);

        Task<IEnumerable<Category>> FilterCategoriesAsync(CategorySearchFilterDto filters);
    }
}
