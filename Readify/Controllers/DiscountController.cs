using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Readify.DTOs.Discount;
using Readify.Service.Interface;

namespace Readify.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/Discount")]

    public class DiscountController(IDiscountService DiscountService): Controller
    {
        [HttpPost("Add")]
        public IActionResult AddAuthor([FromBody] InsertDiscountDto discountDto)
        {
            try
            {
                DiscountService.AddDiscount(discountDto);
                return Ok("Discount added successfully");

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
                var result = DiscountService.GetAllDiscounts();
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
                var result = DiscountService.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteDiscount(Guid id)
        {
            try
            {
                DiscountService.DeleteDiscount(id);
                return Ok("Discount deleted successfully");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateDiscount(Guid id, [FromBody] UpdateDiscountDto discountDto)
        {
            try
            {
                DiscountService.UpdateDiscount(id, discountDto);
                return Ok("Discount updated successfully");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
