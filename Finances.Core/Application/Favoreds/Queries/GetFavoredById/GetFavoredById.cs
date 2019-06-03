using MediatR;
using System;

namespace Finances.Core.Application.Favoreds.Queries.GetFavoredById
{
    public class GetFavoredById : IRequest<FavoredByIdModel>
    {
        public Guid Id { get; set; }
    }
}
