using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Core.Domain.Entities
{
    public class UserHasAccount : BaseEntity
    {
        public string UserId { get; set; }
        public string AccountId { get; set; }
        public User User { get; set; }
        public Account Account { get; set; }
    }
}
