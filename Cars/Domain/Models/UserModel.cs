﻿using Cars.Domain.Base;

namespace Cars.Domain.Models
{
    public class UserModel : ModelId
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}