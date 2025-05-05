using Readify.Data;
using Readify.DTOs.Category;
using Readify.Entities;
using Readify.Service.Interface;

namespace Readify.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddCategory(InsertCategoryDto categoryDto)
        {
            try
            {
                var category = new Category
                {
                    Name = categoryDto.Name,
                    Description = categoryDto.Description
                };

                _context.Categories.Add(category);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding category: " + ex.Message);
            }
        }

        public void DeleteCategory(int id)
        {
            try
            {
                var category = _context.Categories.FirstOrDefault(c => c.CategoryId == id);
                if (category == null)
                    throw new Exception("Category not found");

                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting category: " + ex.Message);
            }
        }

        public List<GetCategoryDto> GetAllCategories()
        {
            try
            {
                var categories = _context.Categories.ToList();
                if (!categories.Any())
                    throw new Exception("No categories found");

                return categories.Select(c => new GetCategoryDto
                {
                    CategoryId = c.CategoryId,
                    Name = c.Name,
                    Description = c.Description
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching categories: " + ex.Message);
            }
        }

        public GetCategoryDto GetCategoryById(int id)
        {
            try
            {
                var category = _context.Categories.FirstOrDefault(c => c.CategoryId == id);
                if (category == null)
                    throw new Exception("Category not found");

                return new GetCategoryDto
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name,
                    Description = category.Description
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching category: " + ex.Message);
            }
        }

        public void UpdateCategory(int id, UpdateCategoryDto categoryDto)
        {
            try
            {
                var category = _context.Categories.FirstOrDefault(c => c.CategoryId == id);
                if (category == null)
                    throw new Exception("Category not found");

                category.Name = categoryDto.Name;
                category.Description = categoryDto.Description;

                _context.Categories.Update(category);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating category: " + ex.Message);
            }
        }
    }
}