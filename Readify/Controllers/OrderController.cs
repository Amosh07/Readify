using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Readify.DTOs.Order;
using Readify.Service.Interface;

namespace Readify.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/order")]

    public class OrderController(IOrderService orderService) : Controller
    {
        [HttpPost("Add")]
        public IActionResult AddOrder([FromBody] InsertOrderDto orderDto)
        {
            try
            {
                orderService.AddOrder(orderDto);
                return Ok("Order added successfully");

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
                var result = orderService.GetAllOrders();
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
                var result = orderService.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteOrder(Guid id)
        {
            try
            {
                orderService.DeleteOrder(id);
                return Ok("Order deleted successfully");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateOrder(Guid id, [FromBody] UpdateOrderDto orderDto)
        {
            try
            {
                orderService.UpdateOrder(id, orderDto);
                return Ok("Order updated successfully");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchOrders([FromQuery] OrderSearchFilterDto filters)
        {
            var result = await orderService.FilterOrdersAsync(filters);
            return Ok(result);
        }
    }
}