using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Core.Domain.Entities
{
    public class UserImage : BaseEntity
    {
        public string UserId { get; set; }
        public string Path { get; set; }
    }
}
