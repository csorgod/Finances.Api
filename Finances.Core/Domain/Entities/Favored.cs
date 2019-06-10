using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using static Finances.Common.Helpers.Enum;

namespace Finances.Core.Domain.Entities
{
    public class Favored : BaseEntity
    {
        public string Name { get; set; }
        public string TaxNumber { get; set; }
        public Status Status { get; set; }
        
        public Guid BelongsToUserId { get; set; }

        [ForeignKey("BelongsToUserId")]
        public User User { get; set; }
    }
}
