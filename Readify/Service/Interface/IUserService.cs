
using Readify.DTOs.User;

namespace Readify.Service.Interface
{
    public interface IUserServices
    {
        void AddUser(InsertUserDto userDto);

        List<GetAllUser> GetAllUsers();

        GetAllUser GetById(string id);

        void DeleteUser(string id);

        void UpdateUser(string id, UpdateUserDto userDto);
    }
}
