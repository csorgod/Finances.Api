using MediatR;
using System;
using System.Collections.Generic;

namespace Finances.Core.Application.Favoreds.Queries.GetFavoredsByUserId
{
    public class GetFavoredsByUserId : IRequest<IList<FavoredsByUserIdModel>>
    {
        public Guid UserId { get; set; }
    }
}
