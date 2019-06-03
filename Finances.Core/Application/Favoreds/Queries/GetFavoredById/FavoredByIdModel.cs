using Finances.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Finances.Core.Application.Favoreds.Queries.GetFavoredById
{
    public class FavoredByIdModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string TaxNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public FavoredByIdAccountModel Account { get; set; }

        public static Expression<Func<Favored, FavoredByIdModel>> Projection
        {
            get
            {
                return customer => new FavoredByIdModel
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    TaxNumber = customer.TaxNumber,
                    CreatedAt = customer.CreatedDate,
                    Account = new FavoredByIdAccountModel
                    {
                        Bank = customer.Account.Bank,
                        BankBranch = customer.Account.BankBranch,
                        BankAccount = customer.Account.BankAccount,
                        BankAccountDigit = customer.Account.BankAccountDigit
                    }
                };
            }
        }

        public static FavoredByIdModel Create(Favored customer)
        {
            return Projection.Compile().Invoke(customer);
        }
    }
}
