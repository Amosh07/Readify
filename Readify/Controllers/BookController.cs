using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Readify.DTOs.Book;
using Readify.Service.Interface;

namespace Readify.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/book")]

    public class BookController(IBookService bookService) : Controller
    {
        [HttpPost("Add")]
        public IActionResult AddAuthor([FromBody] InsertBookDto bookDto)
        {
            try
            {
                bookService.AddBook(bookDto);
                return Ok("Book added successfully");

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
                var result = bookService.GetAllBooks();
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
                var result = bookService.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteBook(Guid id)
        {
            try
            {
                bookService.DeleteBook(id);
                return Ok("Book deleted successfully");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateBook(Guid id, [FromBody] UpdateBookDto bookDto)
        {
            try
            {
                bookService.UpdateBook(id, bookDto);
                return Ok("Book updated successfully");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}