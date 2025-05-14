using Microsoft.AspNetCore.Identity;
using Readify.DTOs.User;
using Readify.Entities;
using Readify.Service.Interface;

namespace Readify.Service
{
    public class UserService : IUserServices
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task AddUser(InsertUserDto userDto)
        {
            try
            {
                var existingUser = await _userManager.FindByEmailAsync(userDto.Email);
                if (existingUser != null)
                {
                    throw new Exception("User with this email already exists.");
                }

                var user = new ApplicationUser
                {
                    UserName = userDto.Email,
                    Email = userDto.Email,
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    Gender = userDto.Gender,
                    ImageUrl = userDto.ImageUrl,
                    RegisteredDate = userDto.RegisteredDate,
                    IsActive = true
                };

                var result = await _userManager.CreateAsync(user, userDto.Password);

                if (!result.Succeeded)
                {
                    throw new Exception("User creation failed: " + string.Join(", ", result.Errors.Select(e => e.Description)));
                }

                if (!await _roleManager.RoleExistsAsync("User"))
                {
                    await _roleManager.CreateAsync(new IdentityRole("User"));
                }

                await _userManager.AddToRoleAsync(user, "User");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw new Exception("Error registering user: " + ex.Message);
            }
        }

        public void DeleteUser(string id)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                throw new Exception("User not found");

            _userManager.DeleteAsync(user).Wait();
        }

        public List<GetAllUser> GetAllUsers()
        {
            var users = _userManager.Users.ToList();
            if (!users.Any())
                throw new Exception("No users found");

            return users.Select(u => new GetAllUser
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Gender = u.Gender,
                ImageUrl = u.ImageUrl,
                RegisteredDate = u.RegisteredDate
            }).ToList();
        }

        public GetAllUser GetById(string id)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                throw new Exception("No active users found");

            return new GetAllUser
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = user.Gender,
                ImageUrl = user.ImageUrl,
                RegisteredDate = user.RegisteredDate
            };
        }

        public void UpdateUser(string id, UpdateUserDto userDto)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                throw new Exception("User not found");

            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.Gender = userDto.Gender;
            user.ImageUrl = userDto.ImageUrl;
            user.IsActive = userDto.IsActive;

            _userManager.UpdateAsync(user).Wait();
        }
    }
}