using System;
using System.ComponentModel.DataAnnotations.Schema;
using static Finances.Common.Helpers.Enum;

namespace Finances.Core.Domain.Entities
{
    public class Incoming : BaseEntity
    {
        public int IncomeType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public Status Status { get; set; }
        public DateTime ReceiveAt { get; set; }
        public bool Recurrent { get; set; }

        public string PersonId { get; set; }

        [ForeignKey("PersonId")]
        public Person Person { get; set; }
    }
}
