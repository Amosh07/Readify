using Microsoft.EntityFrameworkCore;
using Readify.Data;
using Readify.DTOs.CartItem;
using Readify.Entities;
using Readify.Service.Interface;
using System.Net;

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
                var cartitem = new CartItem
                {
                    Qty = cartItemDto.Qty,
                    CreatedDate = cartItemDto.CreatedDate,
                    BookId = cartItemDto.BookId,
                    PersonId = cartItemDto.PersonId,
                };

                _context.CartItems.Add(cartitem);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding cart item: " + ex.Message);
            }
        }
        public void DeleteCartItem(Guid id)
        {
            try
            {
                var cartitem = _context.CartItems.FirstOrDefault(b => b.Id == id);
                if (cartitem == null)
                    throw new Exception("Cart items not found");

                _context.CartItems.Remove(cartitem);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting cart item: " + ex.Message);
            }
        }

        public List<GetAllCartItem> GetAllCartItems()
        {
            try
            {
                var cartitems = _context.CartItems.ToList();
                if (cartitems == null || !cartitems.Any())
                    throw new Exception("No cart items found");

                var result = new List<GetAllCartItem>();
                foreach (var b in cartitems)
                {
                    result.Add(new GetAllCartItem
                    {
                        Id = b.Id,
                        Qty = b.Qty,
                        CreatedDate = b.CreatedDate,
                        PersonId = b.PersonId,
                        BookId = b.BookId,
                    });
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching cart items: " + ex.Message);
            }
        }

        public GetAllCartItem GetById(Guid id)
        {
            try
            {
                var cartitem = _context.CartItems.FirstOrDefault(b => b.Id == id);
                if (cartitem == null)
                    throw new Exception("Cart items not found");

                return new GetAllCartItem
                {
                    Id = cartitem.Id,
                    Qty = cartitem.Qty,
                    CreatedDate = cartitem.CreatedDate,
                    BookId = cartitem.BookId,
                    PersonId= cartitem.PersonId,
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching cart item: " + ex.Message);
            }
        }
        public void UpdateCartItem(Guid id, UpdateCartItemDto cartItemDto)
        {
            try
            {
                var cartitem = _context.CartItems.FirstOrDefault(b => b.Id == id);
                if (cartitem == null)
                    throw new Exception("Cart items not found");

                cartitem.Qty = cartItemDto.Qty;
                cartitem.CreatedDate = cartItemDto.CreatedDate;
                cartitem.BookId = cartItemDto.BookId;
                cartitem.PersonId = cartItemDto.PersonId;

                _context.CartItems.Update(cartitem);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating cart item: " + ex.Message);
            }
        }

        public async Task<IEnumerable<CartItem>> FilterCartItemsAsync(CartItemSearchFilterDto filters)
        {
            var query = _context.CartItems
                .Include(c => c.Book)
                .Include(c => c.User)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filters.PersonId))
                query = query.Where(c => c.PersonId == filters.PersonId);

            if (filters.BookId.HasValue)
                query = query.Where(c => c.BookId == filters.BookId.Value);

            if (filters.MinQty.HasValue)
                query = query.Where(c => c.Qty >= filters.MinQty.Value);

            if (filters.MaxQty.HasValue)
                query = query.Where(c => c.Qty <= filters.MaxQty.Value);

            if (filters.CreatedAfter.HasValue)
                query = query.Where(c => c.CreatedDate >= filters.CreatedAfter.Value);

            if (filters.CreatedBefore.HasValue)
                query = query.Where(c => c.CreatedDate <= filters.CreatedBefore.Value);

            return await query.ToListAsync();
        }
    }
}
