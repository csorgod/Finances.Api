using System;
using static Finances.Common.Helpers.Enum;

namespace Finances.Core.Domain.Entities
{
    public class Favored : BaseEntity
    {
        public Guid BelongsToUserId { get; set; }
        public string Name { get; set; }
        public string TaxNumber { get; set; }
        public Status Status { get; set; }
        public User User { get; set; }
        public Account Account { get; set; }
    }
}
