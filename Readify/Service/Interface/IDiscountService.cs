using Microsoft.AspNetCore.Mvc;
using Readify.DTOs.Discount;

namespace Readify.Service.Interface
{
    public interface IDiscountService
    {
        void AddDiscount(InsertDiscountDto discountDto);

        List<GetAllDiscount> GetAllDiscounts();

        GetAllDiscount GetById(Guid id);

        void DeleteDiscount(Guid id);

        void UpdateDiscount(Guid id, UpdateDiscountDto discountDto);
    }
}
