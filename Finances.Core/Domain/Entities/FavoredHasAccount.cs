using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Core.Domain.Entities
{
    public class FavoredHasAccount : BaseEntity
    {
        public Guid FavoredId { get; set; }
        public Guid AccountId { get; set; }
        public Favored Favored { get; set; }
        public Account Account { get; set; }
    }
}
