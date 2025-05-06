using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Readify.DTOs.Language;
using Readify.Entities;
using Readify.Service.Interface;

namespace Readify.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/language")]

    public class LanguageController(ILanguageService languageService) : Controller
    {
        [HttpPost("Add")]
        public IActionResult AddLanguage([FromBody] InsertLanguageDto languageDto)
        {
            try
            {
                languageService.AddLanguage(languageDto);
                return Ok("Language added successfully");

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
                var result = languageService.GetAllLanguages();
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
                var result = languageService.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateLanguage(Guid id, [FromBody] UpdateLanguageDto languageDto)
        {
            try
            {
                languageService.UpdateLanguage(id, languageDto);
                return Ok("Language updated successfully");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}