using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Finances.Core.Domain.Entities
{
    public class FavoredHasAccount : BaseEntity
    {
        public Guid FavoredId { get; set; }
        public Guid AccountId { get; set; }

        [ForeignKey("FavoredId")]
        public Favored Favored { get; set; }

        [ForeignKey("AccountId")]
        public Account Account { get; set; }
    }
}
