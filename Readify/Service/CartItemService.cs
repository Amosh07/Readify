using Readify.Data;
using Readify.DTOs.CartItem;
using Readify.Entities;
using Readify.Service.Interface;

namespace Readify.Service
{
    public class CartItemService : ICartItemService
    {
        private readonly ApplicationDbContext _context;

        public void AddCartItem(InsertCartItemDto cartItemDto)
        {
            try
            {
                var cartitem = new CartItem
                {
                    Qty = cartItemDto.Qty,
                    CreatedDate = cartItemDto.CreatedDate,
                };

                _context.CartItems.Add(cartitem);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding book: " + ex.Message);
            }
        }
        public void DeleteCartItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<GetAllCartItem> GetAllCartItems()
        {
            throw new NotImplementedException();
        }
        public GetAllCartItem GetById(Guid id)
        {
            throw new NotImplementedException();
        }
        public void UpdateCartItem(Guid id, UpdateCartItemDto cartItemDto)
        {
            throw new NotImplementedException();
        }
    }
}