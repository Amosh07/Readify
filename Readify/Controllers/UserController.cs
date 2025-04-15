using Microsoft.AspNetCore.Mvc;
using Readify.Dto;
using Readify.Service.Interface;

namespace Readify.Controllers
{
    [ApiController]
    [Route("api/User")]
    public class UserController(IUserServices userServices) : Controller
    {
            [HttpPost("Add")]
            public IActionResult AddUser([FromBody] InsertUserDto userdto)
            {
                try
                {
                    userServices.AddUser(userdto);
                    return Ok("User added successfully");
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
                    var result = userServices.GetAllUsers();
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
                    var result = userServices.GetById(id);
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            [HttpPut("{id:guid}")]
            public IActionResult UpadteUser(Guid id, [FromBody] UpdateUserDto userDto)
            {
                try
                {
                    userServices.UpdateUser(id, userDto);
                    return Ok("User updated sucessfully");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
            }
        }
    }
}
    

