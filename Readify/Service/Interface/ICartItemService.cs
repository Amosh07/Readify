using Readify.DTOs.CartItem;
using System;
using System.Collections.Generic;

namespace Readify.Service.Interface
{
    public interface ICartItemService
    {
        void AddCartItem(InsertCartItemDto cartItemDto);

        List<GetAllCartItem> GetAllCartItems();

        GetAllCartItem GetById(int id);

        void DeleteCartItem(int id);

        void UpdateCartItem(int id, UpdateCartItemDto cartItemDto);
    }
}
