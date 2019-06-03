using System;
using System.Collections.Generic;
using System.Text;
using static Finances.Core.Application.Helpers.Enum;

namespace Finances.Common.Session
{
    public class LoginJwt
    {
        public string UserId { get; set; }
        public string Validation { get; set; }
        public DateTime ExpireDate { get; set; }
        public LoginMode LoginBy { get; set; }
    }
}
