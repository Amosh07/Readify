using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Readify.DTOs.Review;
using Readify.Service.Interface;

namespace Readify.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/review")]
    public class ReviewController(IReviewService reviewService) : Controller
    {
        [HttpPost("Add")]
        public IActionResult AddReview([FromBody] InsertReviewDto reviewDto)
        {
            try
            {
                reviewService.AddReview(reviewDto);
                return Ok("Review added successfully");

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
                var result = reviewService.GetAllReview();
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
                var result = reviewService.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteReview(Guid id)
        {
            try
            {
                reviewService.DeleteReview(id);
                return Ok("review deleted successfully");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateReview(Guid id, [FromBody] UpdateReviewDto reviewDto)
        {
            try
            {
                reviewService.UpdateReview(id, reviewDto);
                return Ok("Review updated successfully");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
