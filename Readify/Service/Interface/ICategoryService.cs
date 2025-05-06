using Readify.DTOs.Category;
using System.Collections.Generic;

namespace Readify.Service.Interface
{
    public interface ICategoryService
    {
        void AddCategory(InsertCategoryDto categoryDto);

        List<GetAllCategory> GetAllCategories();

        GetAllCategory GetById(int id);

        void DeleteCategory(int id);

        void UpdateCategory(int id, UpdateCategoryDto categoryDto);
    }
}
