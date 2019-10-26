using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Common.Helpers
{
    public class Enum
    {
        public enum Status
        {
            Active = 0,
            Inactive = 1,
            Blocked = 2,
            Expired = 3
        }

        public enum LoginMode
        {
            None = 0,
            Admin = 1,
            App = 2
        }

        public enum IncomeType
        {
            Fix = 0,
            variable = 1,
            detached = 2
        }

        public enum CardType
        {
            Credit = 0
        }

        public enum AccountType
        {
            CurrentAccount = 0
        }
    }
}
