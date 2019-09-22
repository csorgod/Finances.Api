using Finances.Core.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace Finances.Api.Controllers
{
    public class GetExpensesByUserIdDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public bool Recurrent { get; set; }
    }
}
