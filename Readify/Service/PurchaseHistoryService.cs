using Readify.Data;
using Readify.DTOs.PurchaseHistory;
using Readify.Entities;
using Readify.Service.Interface;

namespace Readify.Service
{
    public class PurchaseHistoryService : IPurchaseHistoryService
    {
        private readonly ApplicationDbContext _context;

        public PurchaseHistoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddPurchaseHistory(InsertPurchaseHistoryDto purchaseHistoryDto)
        {
            try
            {
                var purchaseHistory = new PurchaseHistory
                {
                    PersonId = purchaseHistoryDto.UserId,
                    BookId = purchaseHistoryDto.BookId,
                    Review = purchaseHistoryDto.Review,
                    Comment = purchaseHistoryDto.Comment,
                    PurchaseDate = purchaseHistoryDto.PurchaseDate
                };
                _context.PurchaseHistories.Add(purchaseHistory);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding purchase history: " + ex.Message);
            }
        }

        public void DeletePurchaseHistory(Guid id)
        {
            try
            {
                var purchaseHistory = _context.PurchaseHistories.FirstOrDefault(p => p.Id == id);
                if (purchaseHistory == null)
                    throw new Exception("Purchase history not found");
                _context.PurchaseHistories.Remove(purchaseHistory);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting purchase history: " + ex.Message);
            }
        }

        public List<GetAllPurchaseHistory> GetAllPurchaseHistories()
        {
            try
            {
                var purchaseHistories = _context.PurchaseHistories.ToList();
                var purchaseHistoryDto = new List<GetAllPurchaseHistory>();
                foreach (var p in purchaseHistories)
                {
                    purchaseHistoryDto.Add(new GetAllPurchaseHistory
                    {
                        Id = p.Id,
                        UserId = p.PersonId,
                        BookId = p.BookId,
                        Review = p.Review,
                        Comment = p.Comment,
                        PurchaseDate = p.PurchaseDate
                    });
                }
                return purchaseHistoryDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving purchase histories: " + ex.Message);
            }
        }

        public GetAllPurchaseHistory GetById(Guid id)
        {
            try
            {
                var purchaseHistory = _context.PurchaseHistories.FirstOrDefault(p => p.Id == id);
                if (purchaseHistory == null)
                    throw new Exception("Purchase history not found");
                return new GetAllPurchaseHistory
                {
                    Id = purchaseHistory.Id,
                    UserId = purchaseHistory.PersonId,
                    BookId = purchaseHistory.BookId,
                    Review = purchaseHistory.Review,
                    Comment = purchaseHistory.Comment,
                    PurchaseDate = purchaseHistory.PurchaseDate
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving purchase history: " + ex.Message);
            }
        }

        public void UpdatePurchaseHistory(Guid id, UpdatePurchaseHistoryDto purchaseHistoryDto)
        {
            try
            {
                var purchaseHistory = _context.PurchaseHistories.FirstOrDefault(p => p.Id == id);
                if (purchaseHistory == null)
                    throw new Exception("Purchase history not found");
                purchaseHistory.Review = purchaseHistoryDto.Review;
                purchaseHistory.Comment = purchaseHistoryDto.Comment;
                purchaseHistory.PurchaseDate = purchaseHistoryDto.PurchaseDate;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating purchase history: " + ex.Message);
            }
        }
    }
}
