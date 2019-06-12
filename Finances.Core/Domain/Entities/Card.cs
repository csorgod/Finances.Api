using System;
using System.ComponentModel.DataAnnotations.Schema;
using static Finances.Common.Helpers.Enum;

namespace Finances.Core.Domain.Entities
{
    public class Card : BaseEntity
    {
        public CardType Type { get; set; }
        public string Holder { get; set; }
        public string Number { get; set; }
        public DateTime ExpireDate { get; set; }

        public Guid PersonId { get; set; }

        [ForeignKey("PersonId")]
        public Person Person { get; set; }
    }
}
