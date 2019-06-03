using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Core.Application.Favoreds.Queries.GetFavoredById
{
    public class FavoredByIdAccountModel
    {
        public int? Bank { get; set; }
        
        public int? BankBranch { get; set; }
        
        public int? BankAccount { get; set; }
        
        public int? BankAccountDigit { get; set; }
    }
}
