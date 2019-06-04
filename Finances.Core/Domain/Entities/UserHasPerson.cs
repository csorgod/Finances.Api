using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Core.Domain.Entities
{
    public class UserHasPerson : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid PersonId { get; set; }
        public User User { get; set; }
        public Person Person { get; set; }
    }
}
