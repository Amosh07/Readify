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
            throw new NotImplementedException();
        }

        public void DeleteCartItem(int id)
        {
            throw new NotImplementedException();
        }

        public List<GetAllCartItem> GetAllCartItems()
        {
            throw new NotImplementedException();
        }

        public GetAllCartItem GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateCartItem(int id, UpdateCartItemDto cartItemDto)
        {
            throw new NotImplementedException();
        }
    }
}