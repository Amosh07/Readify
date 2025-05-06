using Microsoft.AspNetCore.Mvc;

namespace Readify.DTOs.Discount
{
    public class InsertDiscountDto 
    {
        public int DiscountPercentage { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool isOnSale { get; set; }

        public Guid BookId { get; set; }
    }
}
