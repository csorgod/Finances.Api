using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Core.Application.Authorization.Commands.SignIn
{
    class UserAuth
    {
        public string JwtToken { get; set; }
        public UserData User { get; set; }
    }
}
