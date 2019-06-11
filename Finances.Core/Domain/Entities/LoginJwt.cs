using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static Finances.Common.Helpers.Enum;

namespace Finances.Core.Domain.Entities
{
    public class LoginJwt : BaseEntity
    {
        public string Header { get; set; }
        public string Payload { get; set; }
        public string Signature { get; set; }
        public Status Status { get; set; }
        public DateTime ExpireDate { get; set; }
        
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
