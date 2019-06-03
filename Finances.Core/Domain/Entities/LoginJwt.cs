using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Core.Domain.Entities
{
    public class LoginJwt : BaseEntity
    {
        public string UserId { get; set; }
        public string Header { get; set; }
        public string Payload { get; set; }
        public string Signature { get; set; }
        public int Status { get; set; }
        public DateTime ExpireDate { get; set; }
        public User User { get; set; }
    }
}
