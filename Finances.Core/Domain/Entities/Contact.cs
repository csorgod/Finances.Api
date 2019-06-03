using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Core.Domain.Entities
{
    public class Contact : BaseEntity
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
