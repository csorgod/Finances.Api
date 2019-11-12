using Finances.Core.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace Finances.Core.Application.Favoreds.Queries.GetFavoredsByUserId
{
    public class FavoredsByUserIdModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string TaxNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public FavoredsByUserIdAccountModel Account { get; set; }

        public static Expression<Func<Favored, FavoredsByUserIdModel>> Projection
        {
            get
            {
                return favored => new FavoredsByUserIdModel
                {
                    Id = favored.Id,
                    Name = favored.Name,
                    TaxNumber = favored.TaxNumber,
                    CreatedAt = favored.CreatedDate
                };
            }
        }

        public static FavoredsByUserIdModel Create(Favored customer)
            => Projection.Compile().Invoke(customer);
    }
}