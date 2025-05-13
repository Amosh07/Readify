using Microsoft.EntityFrameworkCore;
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
                    Description = categoryDto.Description,
                };

                _context.Categorys.Add(category);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding category: " + ex.Message);
            }
        }

        public void DeleteCategory(Guid id)
        {
            try
            {
                var category = _context.Categorys.FirstOrDefault(b => b.Id == id);
                if (category == null)
                    throw new Exception("categorys not found");

                _context.Categorys.Remove(category);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting category: " + ex.Message);
            }
        }

        public List<GetAllCategory> GetAllCategories()
        {
            try
            {
                var categories = _context.Categorys.ToList();
                if (categories == null || !categories.Any())
                    throw new Exception("No category found");

                var result = new List<GetAllCategory>();
                foreach (var b in categories)
                {
                    result.Add(new GetAllCategory
                    {
                        Id = b.Id,
                        Name = b.Name,
                        Description = b.Description,
                    });
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching categories: " + ex.Message);
            }
        }

        public GetAllCategory GetById(Guid id)
        {
            try
            {
                var category = _context.Categorys.FirstOrDefault(b => b.Id == id);
                if (category == null)
                    throw new Exception("Category not found");

                return new GetAllCategory
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description,
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching category: " + ex.Message);
            }
        }

        public void UpdateCategory(Guid id, UpdateCategoryDto categoryDto)
        {
            try
            {
                var category = _context.Categorys.FirstOrDefault(b => b.Id == id);
                if (category == null)
                    throw new Exception("Category not found");

                category.Id = categoryDto.Id;
                category.Name = categoryDto.Name;
                category.Description = categoryDto.Description;

                _context.Categorys.Update(category);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating category: " + ex.Message);
            }
        }

        public async Task<IEnumerable<Category>> FilterCategoriesAsync(CategorySearchFilterDto filters)
        {
            var query = _context.Categorys.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filters.Name))
                query = query.Where(c => c.Name.Contains(filters.Name));

            if (!string.IsNullOrWhiteSpace(filters.Description))
                query = query.Where(c => c.Description.Contains(filters.Description));

            return await query.ToListAsync();
        }
    }
}