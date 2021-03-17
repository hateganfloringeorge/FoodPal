using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodPal.Auth.Dto
{
    public class LoginUserRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
