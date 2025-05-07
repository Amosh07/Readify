using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Readify.DTOs.OrderItem;
using Readify.Service.Interface;

namespace Readify.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/orderitem")]

    public class OrderItemController(IOrderItemService orderitemService) : Controller
    {
        [HttpPost("Add")]
        public IActionResult AddCartItem([FromBody] InsertOrderItemDto orderitemDto)
        {
            try
            {
                orderitemService.AddOrderItem(orderitemDto);
                return Ok("OrderItem added successfully");

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
                var result = orderitemService.GetAllOrderItems();
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
                var result = orderitemService.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteOrderItem(Guid id)
        {
            try
            {
                orderitemService.DeleteOrderItem(id);
                return Ok("OrderItem deleted successfully");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateOrderItem(Guid id, [FromBody] UpdateOrderItemDto orderitemDto)
        {
            try
            {
                orderitemService.UpdateOrderItem(id, orderitemDto);
                return Ok("OrderItem updated successfully");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}