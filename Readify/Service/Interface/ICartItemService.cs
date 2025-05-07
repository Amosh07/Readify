using Readify.DTOs.CartItem;

namespace Readify.Service.Interface
{
    public interface ICartItemService
    {
        void AddCartItem(InsertCartItemDto cartItemDto);

        List<GetAllCartItem> GetAllCartItems();

        GetAllCartItem GetById(Guid id);

        void DeleteCartItem(Guid id);

        void UpdateCartItem(Guid id, UpdateCartItemDto cartItemDto);
    }
}
