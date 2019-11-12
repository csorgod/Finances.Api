using Finances.Common.Data;
using MediatR;
using System;

namespace Finances.Core.Application.Favoreds.Queries.GetFavoredsByUserId
{
    public class FavoredsByUserId : IRequest<JsonDefaultResponse>
    {
        public Guid UserId { get; set; }
    }
}
