using Microsoft.AspNetCore.Identity;
using Readify.Constant;

namespace Readify.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public GenderType Gender { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public DateTime RegisteredDate { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
    }
}
