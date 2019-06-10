using Finances.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Finances.Core.Application.Favoreds.Queries.GetFavoredById
{
    public class FavoredByIdAccountModel
    {
        public int? Bank { get; set; }
        public int? BankBranch { get; set; }
        public int? BankAccount { get; set; }
        public int? BankAccountDigit { get; set; }

        public static Expression<Func<Account, FavoredByIdAccountModel>> Projection
        {
            get
            {
                return Account => new FavoredByIdAccountModel
                {
                    Bank = Account.Bank,
                    BankBranch = Account.BankBranch,
                    BankAccount = Account.BankAccount,
                    BankAccountDigit = Account.BankAccountDigit
                };
            }
        }

        public static FavoredByIdAccountModel Create(Account account)
        {
            return Projection.Compile().Invoke(account);
        }
    }
}
