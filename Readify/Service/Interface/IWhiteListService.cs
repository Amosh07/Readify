using Readify.DTOs.WhiteList;

namespace Readify.Service.Interface
{
    public interface IWhiteListService
    {
        void AddToWhiteList(InsertWhiteListDto whiteListDto);

        List<GetAllWhiteList> GetAllWhiteList();

        GetAllWhiteList GetById(Guid id);

        void DeleteWhiteList(Guid id);

        void UpdateWhiteList(Guid id, UpdateWhiteListDto whiteListDto);
    }
}
