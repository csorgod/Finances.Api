using Finances.Core.Domain.Entities;
using System;
using System.Linq.Expressions;

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
                return favored => new FavoredByIdModel
                {
                    Id = favored.Id,
                    Name = favored.Name,
                    TaxNumber = favored.TaxNumber,
                    CreatedAt = favored.CreatedDate
                };
            }
        }

        public static FavoredByIdModel Create(Favored customer)
            => Projection.Compile().Invoke(customer);
    }
}
