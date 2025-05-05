using Readify.Data;
using Readify.DTOs.CartItem;
using Readify.Entities;
using Readify.Service.Interface;

namespace Readify.Service
{
    public class CartItemService : ICartItemService
    {
        private readonly ApplicationDbContext _context;

        public CartItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddCartItem(InsertCartItemDto cartItemDto)
        {
            try
            {
                var cartItem = new CartItem
                {
                    UserId = cartItemDto.UserId,
                    BookId = cartItemDto.BookId,
                    Qty = cartItemDto.Qty,
                    CreatedDate = DateTime.UtcNow
                };

                _context.CartItems.Add(cartItem);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding cart item: " + ex.Message);
            }
        }

        public void DeleteCartItem(int userId, int bookId)
        {
            try
            {
                var cartItem = _context.CartItems
                    .FirstOrDefault(ci => ci.UserId == userId && ci.BookId == bookId);

                if (cartItem == null)
                    throw new Exception("Cart item not found");

                _context.CartItems.Remove(cartItem);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting cart item: " + ex.Message);
            }
        }

        public List<GetCartItemDto> GetCartItemsByUser(int userId)
        {
            try
            {
                var cartItems = _context.CartItems
                    .Where(ci => ci.UserId == userId)
                    .ToList();

                if (!cartItems.Any())
                    throw new Exception("No cart items found for this user");

                return cartItems.Select(ci => new GetCartItemDto
                {
                    UserId = ci.UserId,
                    BookId = ci.BookId,
                    Qty = ci.Qty,
                    CreatedDate = ci.CreatedDate
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching cart items: " + ex.Message);
            }
        }

        public void UpdateCartItemQty(int userId, int bookId, UpdateCartItemQtyDto updateDto)
        {
            try
            {
                var cartItem = _context.CartItems
                    .FirstOrDefault(ci => ci.UserId == userId && ci.BookId == bookId);

                if (cartItem == null)
                    throw new Exception("Cart item not found");

                cartItem.Qty = updateDto.Qty;
                _context.CartItems.Update(cartItem);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating cart item quantity: " + ex.Message);
            }
        }
    }
}