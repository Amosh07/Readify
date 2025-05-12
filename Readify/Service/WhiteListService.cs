using Readify.Data;
using Readify.DTOs.WhiteList;
using Readify.Entities;
using Readify.Service.Interface;

namespace Readify.Service
{
    public class WhiteListService : IWhiteListService
    {
        private readonly ApplicationDbContext _context;

        public WhiteListService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddToWhiteList(InsertWhiteListDto whiteListDto)
        {
            try
            {
                var whiteList = new Whitelist
                {
                    Id = whiteListDto.UserId,
                    PersonId = whiteListDto.UserId,
                    BookId = whiteListDto.BookId,
                    CreatedDate = whiteListDto.CreatedDate
                };
                _context.Whitelists.Add(whiteList);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding to whitelist: " + ex.Message);
            }
        }

        public void DeleteWhiteList(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<GetAllWhiteList> GetAllWhiteList()
        {
            try
            {
                var whiteList = _context.Whitelists.ToList();
                if (whiteList == null || !whiteList.Any())
                    throw new Exception("No whitelist found");
                var whiteListDto = new List<GetAllWhiteList>();
                foreach (var w in whiteList)
                {
                    whiteListDto.Add(new GetAllWhiteList
                    {
                        Id = w.Id,
                        UserId = w.PersonId,
                        BookId = w.BookId,
                        CreatedDate = w.CreatedDate
                    });
                }
                return whiteListDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving whitelist: " + ex.Message);
            }
        }

        public GetAllWhiteList GetById(Guid id)
        {
            try
            {
                var whiteList = _context.Whitelists.FirstOrDefault(w => w.Id == id);
                if (whiteList == null)
                    throw new Exception("Whitelist not found");
                return new GetAllWhiteList
                {
                    Id = whiteList.Id,
                    UserId = whiteList.PersonId,
                    BookId = whiteList.BookId,
                    CreatedDate = whiteList.CreatedDate
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving whitelist by ID: " + ex.Message);
            }
        }

        public void RemoveFromWhiteList(Guid id)
        {
            try
            {
                var whiteList = _context.Whitelists.FirstOrDefault(w => w.Id == id);
                if (whiteList == null)
                    throw new Exception("Whitelist not found");
                _context.Whitelists.Remove(whiteList);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error removing from whitelist: " + ex.Message);
            }
        }

        public void UpdateWhiteList(Guid id, UpdateWhiteListDto whiteListDto)
        {
            try
            {
                var whiteList = _context.Whitelists.FirstOrDefault(w => w.Id == id);
                if (whiteList == null)
                    throw new Exception("Whitelist not found");
                whiteList.PersonId = whiteListDto.UserId;
                whiteList.BookId = whiteListDto.BookId;
                whiteList.CreatedDate = whiteListDto.CreatedDate;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating whitelist: " + ex.Message);
            }
        }
    }
}
