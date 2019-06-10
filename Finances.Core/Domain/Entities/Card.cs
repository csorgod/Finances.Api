using System;
using static Finances.Common.Helpers.Enum;

namespace Finances.Core.Domain.Entities
{
    public class Card : BaseEntity
    {
        public Guid PersonId { get; set; }
        public CardType Type { get; set; }
        public string Holder { get; set; }
        public string Number { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
