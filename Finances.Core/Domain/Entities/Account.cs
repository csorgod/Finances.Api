using System;
using System.Collections.Generic;
using System.Text;
using static Finances.Core.Application.Helpers.Enum;

namespace Finances.Core.Domain.Entities
{
    public class Account : BaseEntity 
    {
        public int Bank { get; set; }
        public int BankBranch { get; set; }
        public int BankAccount { get; set; }
        public int BankAccountDigit { get; set; }
        public Status Status { get; set; }
    }
}
