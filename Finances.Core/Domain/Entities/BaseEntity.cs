using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Core.Domain.Entities
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
        }
        
        public Guid Id { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime UpdatedDate { get; private set; }
    }
}
