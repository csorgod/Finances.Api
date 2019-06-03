using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Core.Domain.Entities
{
    public class UserHasPerson : BaseEntity
    {
        public string UserId { get; set; }
        public string PersonId { get; set; }
        public User User { get; set; }
        public Person Person { get; set; }
    }
}
