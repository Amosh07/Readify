using Readify.Data;
using Readify.DTOs.User;
using Readify.Entities;
using Readify.Service.Interface;

namespace Readify.Service
{
    public class UserService : IUserServices
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddUser(InsertUserDto userDto)
        {
            try
            {
                var user = new User
                {
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    Gender = userDto.Gender,
                    ImageUrl = userDto.ImageUrl,
                    RegisteredDate = userDto.RegisteredDate,
                    IsActive = true
                };

                _context.Users.Add(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding users: " + ex.Message);
            }
        }

        public void DeleteUser(Guid id)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Id == id);
                if (user == null)
                    throw new Exception("User not found");

                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting User" + ex.Message);
            }
        }

        public List<GetAllUser> GetAllUsers()
        {
            try
            {
                var users = _context.Users.Where(u => u.IsActive).ToList();
                if (users == null)
                    throw new Exception("No active users found");

                var result = new List<GetAllUser>();
                foreach (var u in users)
                {
                    result.Add(new GetAllUser
                    {
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Gender = u.Gender,
                        ImageUrl = u.ImageUrl,
                        RegisteredDate = u.RegisteredDate,
                    });
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching users: " + ex.Message);
            }
        }

        public GetAllUser GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(Guid id, UpdateUserDto userDto)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Id == id);
                if (user == null)
                    throw new Exception("User not found");
                user.FirstName = userDto.FirstName;
                user.LastName = userDto.LastName;
                user.Gender = userDto.Gender;
                user.ImageUrl = userDto.ImageUrl;
                user.IsActive = userDto.IsActive;

                _context.Users.Update(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error Updating user" + ex.Message);
            }
        }
    }
}

