using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Readify.DTOs.WhiteList;
using Readify.Entities;
using Readify.Service.Interface;

namespace Readify.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/whitelist")]

    public class WhiteListController(IWhiteListService whitelistService) : Controller
    {
        [HttpPost("Add")]
        public IActionResult AddWhiteList([FromBody] InsertWhiteListDto whitelistDto)
        {
            try
            {
                whitelistService.AddToWhiteList(whitelistDto);
                return Ok("WhiteList added successfully");

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
                var result = whitelistService.GetAllWhiteList();
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
                var result = whitelistService.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateWhiteList(Guid id, [FromBody] UpdateWhiteListDto whitelistDto)
        {
            try
            {
                whitelistService.UpdateWhiteList(id, whitelistDto);
                return Ok("WhiteList updated successfully");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}