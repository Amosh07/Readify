using Readify.Data;
using Readify.DTOs.Category;
using Readify.Service.Interface;

namespace Readify.Service
{
    public class CategoryService : ICategoryService
    
    {
        private readonly ApplicationDbContext _context;

        public void AddCategory(InsertCategoryDto categoryDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }

        public List<GetAllCategory> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public GetAllCategory GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateCategory(int id, UpdateCategoryDto categoryDto)
        {
            throw new NotImplementedException();
        }
    }
}