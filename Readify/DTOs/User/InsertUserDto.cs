﻿using Readify.Constant;

namespace Readify.DTOs.User
{
    public class InsertUserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public GenderType Gender { get; set; }

        public string ImageUrl { get; set; }

        public DateTime RegisteredDate { get; set; }
    }
}
