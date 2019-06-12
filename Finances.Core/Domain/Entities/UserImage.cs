using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finances.Core.Domain.Entities
{
    public class UserImage : BaseEntity
    {  
        public string Path { get; set; }
        
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
