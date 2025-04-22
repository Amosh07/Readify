
using Readify.DTOs.User;

namespace Readify.Service.Interface
{
    public interface IUserServices
    {
        void AddUser(InsertUserDto userDto);

        List<GetAllUser> GetAllUsers();

        GetAllUser GetById(Guid id);

        void DeleteUser(Guid id);

        void UpdateUser(Guid id, UpdateUserDto userDto);
    }
}
