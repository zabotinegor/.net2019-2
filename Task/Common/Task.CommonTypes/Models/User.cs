﻿using Task.CommonTypes.Interfaces;

namespace Task.CommonTypes.Models
{
    public class User : IUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
