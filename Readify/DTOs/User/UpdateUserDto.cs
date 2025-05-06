using Readify.Constant;

namespace Readify.DTOs.User
{
    public class UpdateUserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public GenderType Gender { get; set; }

        public string ImageUrl { get; set; }

        public DateTime RegisteredDate { get; set; }

        public bool IsActive { get; set; }
    }
}
