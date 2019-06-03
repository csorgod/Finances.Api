using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Core.Domain.Entities
{
    public class PersonHasContact : BaseEntity
    {
        public string PersonId { get; set; }
        public string ContactId { get; set; }
        public Person Person { get; set; }
        public Contact Contact { get; set; }
    }
}
