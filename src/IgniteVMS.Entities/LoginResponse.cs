using System;
using System.Collections.Generic;
using System.Text;

namespace IgniteVMS.Entities
{
    public class LoginResponse
    {
        public string Jwt { get; set; }
        public UserResponse CurrentUser { get; set; }
    }
}
