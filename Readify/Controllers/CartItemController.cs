using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Readify.DTOs.CartItem;
using Readify.Service.Interface;

namespace Readify.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/cartitem")]

    public class CartItemController(ICartItemService cartitemService) : Controller
    {
        [HttpPost("Add")]
        public IActionResult AddCartItem([FromBody] InsertCartItemDto cartitemDto)
        {
            try
            {
                cartitemService.AddCartItem(cartitemDto);
                return Ok("CartItem added successfully");

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
                var result = cartitemService.GetAllCartItems();
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
                var result = cartitemService.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteCartItemUser(Guid id)
        {
            try
            {
                cartitemService.DeleteCartItem(id);
                return Ok("CartItem deleted successfully");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateCartItem(Guid id, [FromBody] UpdateCartItemDto cartitemDto)
        {
            try
            {
                cartitemService.UpdateCartItem(id, cartitemDto);
                return Ok("CartItem updated successfully");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}