using static Finances.Common.Helpers.Enum;

namespace Finances.Core.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Status Status { get; set; }
    }
}
