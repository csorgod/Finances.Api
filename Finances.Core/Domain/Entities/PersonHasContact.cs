using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Finances.Core.Domain.Entities
{
    public class PersonHasContact : BaseEntity
    {
        public Guid PersonId { get; set; }
        public Guid ContactId { get; set; }

        [ForeignKey("PersonId")]
        public Person Person { get; set; }

        [ForeignKey("ContactId")]
        public Contact Contact { get; set; }
    }
}
