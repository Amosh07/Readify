using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Readify.DTOs.Publisher;
using Readify.Service.Interface;

namespace Readify.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/publisher")]

    public class PublisherController(IPublisherService publisherService) : Controller
    {
        [HttpPost("Add")]
        public IActionResult AddPublisher([FromBody] InsertPublisherDto publisherDto)
        {
            try
            {
                publisherService.AddPublisher(publisherDto);
                return Ok("Publisher added successfully");

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
                var result = publisherService.GetAllPublishers();
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
                var result = publisherService.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdatePublisher(Guid id, [FromBody] UpdatePublisherDto publisherDto)
        {
            try
            {
                publisherService.UpdatePublisher(id, publisherDto);
                return Ok("Publisher updated successfully");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

