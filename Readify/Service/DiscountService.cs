using Readify.Data;
using Readify.DTOs.Discount;
using Readify.Entities;
using Readify.Service.Interface;

namespace Readify.Service
{
    public class DiscountService : IDiscountService
    
    {
        private readonly ApplicationDbContext _context;

        public DiscountService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddDiscount(InsertDiscountDto discountDto)
        {
            try
            {
                var discount = new Discount
                {
                    DiscountPercentage = discountDto.DiscountPercentage,
                    StartDate = discountDto.StartDate,
                    EndDate = discountDto.EndDate,
                    isOnSale = discountDto.isOnSale,
                    BookId = discountDto.BookId,
                };

                _context.Discounts.Add(discount);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding discount: " + ex.Message);
            }
        }

        public void DeleteDiscount(Guid id)
        {
            try
            {
                var discount = _context.Discounts.FirstOrDefault(b => b.Id == id);
                if (discount == null)
                    throw new Exception("discount not found");

                _context.Discounts.Remove(discount);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting discount: " + ex.Message);
            }
        }

        public List<GetAllDiscount> GetAllDiscounts()
        {
            try
            {
                var discounts = _context.Discounts.ToList();
                if (discounts == null || !discounts.Any())
                    throw new Exception("No discounts found");

                var result = new List<GetAllDiscount>();
                foreach (var b in discounts)
                {
                    result.Add(new GetAllDiscount
                    {
                        DiscountPercentage = b.DiscountPercentage,
                        StartDate = b.StartDate,
                        EndDate = b.EndDate,
                        isOnSale = b.isOnSale,
                        BookId = b.BookId,
                    });
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching discount: " + ex.Message);
            }
        }

        public GetAllDiscount GetById(Guid id)
        {
            try
            {
                var discount = _context.Discounts.FirstOrDefault(b => b.Id == id);
                if (discount == null)
                    throw new Exception("discount not found");

                return new GetAllDiscount
                {
                    DiscountPercentage = discount.DiscountPercentage,
                    StartDate = discount.StartDate,
                    EndDate = discount.EndDate,
                    isOnSale = discount.isOnSale,
                    BookId = discount.BookId,
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching discount: " + ex.Message);
            }
        }

        public void UpdateDiscount(Guid id, UpdateDiscountDto discountDto)
        {
            try
            {
                var discount = _context.Discounts.FirstOrDefault(b => b.Id == id);
                if (discount == null)
                    throw new Exception("discount not found");

                discount.DiscountPercentage = discountDto.DiscountPercentage;
                    discount.StartDate = discountDto.StartDate;
                discount.EndDate = discountDto.EndDate;
                discount.isOnSale = discountDto.isOnSale;
                discount.BookId = discountDto.BookId;

                _context.Discounts.Update(discount);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating discount: " + ex.Message);
            }
        }
        List<GetAllDiscount> IDiscountService.GetAllDiscounts()
        {
            throw new NotImplementedException();
        }
    }
}