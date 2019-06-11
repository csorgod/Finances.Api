using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Finances.Core.Domain.Entities
{
    public class UserHasPerson : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid PersonId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("PersonId")]
        public Person Person { get; set; }
    }
}
