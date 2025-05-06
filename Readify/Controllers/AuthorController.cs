using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Readify.DTOs.Author;
using Readify.Entities;
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

    }
}