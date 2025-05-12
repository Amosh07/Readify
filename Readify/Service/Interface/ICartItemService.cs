using Readify.DTOs.CartItem;
using Readify.Entities;

namespace Readify.Service.Interface
{
    public interface ICartItemService
    {
        void AddCartItem(InsertCartItemDto cartItemDto);

        List<GetAllCartItem> GetAllCartItems();

        GetAllCartItem GetById(Guid id);

        void DeleteCartItem(Guid id);

        void UpdateCartItem(Guid id, UpdateCartItemDto cartItemDto);

        Task<IEnumerable<CartItem>> FilterCartItemsAsync(CartItemSearchFilterDto filters);
    }
}
