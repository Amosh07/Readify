using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Readify.DTOs.User;
using Readify.Service.Interface;

namespace Readify.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/User")]
    public class UserController(IUserServices userServices) : Controller
    {
            [HttpPost("Add")]
            public async Task<IActionResult> AddUser([FromBody] InsertUserDto userdto)
            {
                try
                {
                    await userServices.AddUser(userdto); // ✅ Await the async method
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

            [HttpGet("{id}")]
            public IActionResult GetById(string id)
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

            [HttpDelete("{id}")]
            public IActionResult DeleteUser(string id)
            {
                try
                {
                userServices.DeleteUser(id);
                return Ok("user deleted successfully");

                }
            catch (Exception ex)
                {
                return BadRequest(ex.Message);
                }
            }

           [HttpPut("{id}")]
            public IActionResult UpdateUser(string id, [FromBody] UpdateUserDto userDto)
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
    

