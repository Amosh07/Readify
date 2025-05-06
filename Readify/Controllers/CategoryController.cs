using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Readify.DTOs.Category;
using Readify.Entities;
using Readify.Service.Interface;

namespace Readify.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/category")]

    public class CategoryController(ICategoryService categoryService) : Controller
    {
        [HttpPost("Add")]
        public IActionResult AddCategory([FromBody] InsertCategoryDto categoryDto)
        {
            try
            {
                categoryService.AddCategory(categoryDto);
                return Ok("Category added successfully");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetByAll")]
        public IActionResult GetByAll()
        {
            try
            {
                var result = categoryService.GetAllCategories();
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var result = categoryService.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateBook(Guid id, [FromBody] UpdateCategoryDto categoryDto)
        {
            try
            {
                categoryService.UpdateCategory(id, categoryDto);
                return Ok("Category updated successfully");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}