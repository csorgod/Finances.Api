using Finances.Core.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace Finances.Core.Application.Favoreds.Queries.GetFavoredsByUserId
{
    public class FavoredsByUserIdAccountModel
    {
        public int? Bank { get; set; }
        public int? BankBranch { get; set; }
        public int? BankAccount { get; set; }
        public int? BankAccountDigit { get; set; }

        public static Expression<Func<Account, FavoredsByUserIdAccountModel>> Projection
        {
            get
            {
                return Account => new FavoredsByUserIdAccountModel
                {
                    Bank = Account.Bank,
                    BankBranch = Account.BankBranch,
                    BankAccount = Account.BankAccount,
                    BankAccountDigit = Account.BankAccountDigit
                };
            }
        }

        public static FavoredsByUserIdAccountModel Create(Account account)
        {
            return Projection.Compile().Invoke(account);
        }
    }
}