using System;
using static Finances.Common.Helpers.Enum;

namespace Finances.Common.Session
{
    public class LoginJwt
    {
        public Guid UserId { get; set; }
        public string Validation { get; set; }
        public DateTime ExpireDate { get; set; }
        public LoginMode LoginBy { get; set; }
    }
}
