﻿
namespace IgniteVMS.Entities
{
    public class CreateUserRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool isAdmin { get; set; }
    }
}
