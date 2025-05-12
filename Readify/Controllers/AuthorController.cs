using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Readify.DTOs.Author;
using Readify.Service;
using Readify.Service.Interface;

namespace Readify.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/author")]

    public class AuthorController(IAuthorService authorService) : Controller
    {
        [HttpPost("Add")]
        public IActionResult AddAuthor([FromBody] InsertAuthorDto authorDto)
        {
            try
            {
                authorService.AddAuthor(authorDto);
                return Ok("Author added successfully");

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
                var result = authorService.GetAllAuthors();
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
                var result = authorService.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteAuthor(Guid id)
        {
            try
            {
                authorService.DeleteAuthor(id);
                return Ok("author deleted successfully");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateAuthor(Guid id, [FromBody] UpdateAuthorDto authorDto)
        {
            try
            {
                authorService.UpdateAuthor(id, authorDto);
                return Ok("Author updated successfully");

            }
            catch (Exception ex)
            { 
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchAuthors([FromQuery] AuthorSearchFilterDto filters)
        {
            var authors = await authorService.FilterAuthorsAsync(filters);
            return Ok(authors);
        }

    }
}