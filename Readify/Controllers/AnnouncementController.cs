using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Readify.DTOs.Announcement;
using Readify.Service.Interface;

namespace Readify.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/announcement")]
    public class AnnouncementController(IAnnouncementService announcementService) : Controller
    {
            [HttpPost("Add")]
            public IActionResult AddAnnouncement([FromBody] InsertAnnouncementDto announcementDto)
            {
                try
                {
                    announcementService.AddAnnouncement(announcementDto);
                    return Ok("Announcement added successfully");

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
                    var result = announcementService.GetAllAnnouncements();
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
                    var result = announcementService.GetById(id);
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            [HttpDelete("{id:guid}")]
            public IActionResult DeleteAnnouncement(Guid id)
            {
                try
                {
                    announcementService.DeleteAnnouncement(id);
                    return Ok("announcement deleted successfully");

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            [HttpPut("{id:guid}")]
            public IActionResult UpdateAnnouncement(Guid id, [FromBody] UpdateAnnouncementDto announcementDto)
            {
                try
                {
                    announcementService.UpdateAnnouncement(id, announcementDto);
                    return Ok("Announcement updated successfully");

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
    }
}
