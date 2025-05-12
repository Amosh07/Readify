using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Readify.DTOs.PurchaseHistory;
using Readify.Service;
using Readify.Service.Interface;

namespace Readify.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/purchasehistory")]

    public class PurchaseHistoryController(IPurchaseHistoryService purchasehistoryService) : Controller
    {
        [HttpPost("Add")]
        public IActionResult AddPurchaseHistory([FromBody] InsertPurchaseHistoryDto purchasehistoryDto)
        {
            try
            {
                purchasehistoryService.AddPurchaseHistory(purchasehistoryDto);
                return Ok("PurchaseHistory added successfully");

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
                var result = purchasehistoryService.GetAllPurchaseHistories();
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
                var result = purchasehistoryService.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeletePurchaseHistory(Guid id)
        {
            try
            {
                purchasehistoryService.DeletePurchaseHistory(id);
                return Ok("PurchaseHistory deleted successfully");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdatePurchaseHistory(Guid id, [FromBody] UpdatePurchaseHistoryDto purchasehistoryDto)
        {
            try
            {
                purchasehistoryService.UpdatePurchaseHistory(id, purchasehistoryDto);
                return Ok("PurchaseHistory updated successfully");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("search")]
        public IActionResult Filter([FromQuery] PurchaseHistoryFilterDto filter)
        {
            var result = purchasehistoryService.Filter(filter);
            return Ok(result);
        }
    }
}