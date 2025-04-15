using Readify.Constant;

namespace Readify.Dto
{
    public class GetAllUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public GenderType Gender { get; set; }

        public string ImageUrl { get; set; }

        public DateTime RegisteredDate { get; set; }
    }
}
