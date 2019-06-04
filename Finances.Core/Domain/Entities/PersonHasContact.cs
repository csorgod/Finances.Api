using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Core.Domain.Entities
{
    public class PersonHasContact : BaseEntity
    {
        public Guid PersonId { get; set; }
        public Guid ContactId { get; set; }
        public Person Person { get; set; }
        public Contact Contact { get; set; }
    }
}
