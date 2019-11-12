using Finances.Common.Data;
using MediatR;
using System;

namespace Finances.Core.Application.Favoreds.Queries.GetFavoredById
{
    public class FavoredById : IRequest<JsonDefaultResponse>
    {
        public Guid Id { get; set; }
    }
}
