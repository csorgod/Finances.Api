using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Core.Application.Accounts.Commands
{
    public class CreateAccount : IRequest
    {
        public int? Bank { get; set; }
        public int? BankBranch { get; set; }
        public int? BankAccount { get; set; }
        public int? BankAccountDigit { get; set; }
    }
}
