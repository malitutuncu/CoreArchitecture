﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.User
{
    public class UserLoginDto
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
