using System.ComponentModel.DataAnnotations.Schema;

namespace Finances.Core.Domain.Entities
{
    public class UserHasAccount : BaseEntity
    {
        public string UserId { get; set; }
        public string AccountId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("AccountId")]
        public Account Account { get; set; }
    }
}
