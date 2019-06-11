using Finances.Core.Application.Exceptions;
using Finances.Core.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Finances.Core.Application.Favoreds.Queries.GetFavoredsByUserId
{
    public class GetFavoredsByUserIdHandler : IRequestHandler<GetFavoredsByUserId, IList<FavoredsByUserIdModel>>
    {
        private readonly IFinancesDbContext _context;

        public GetFavoredsByUserIdHandler(IFinancesDbContext context)
        {
            _context = context;
        }

        public async Task<IList<FavoredsByUserIdModel>> Handle(GetFavoredsByUserId request, CancellationToken cancellationToken)
        {
            var favoredList = new List<FavoredsByUserIdModel>();

            var favoreds = await _context.Favored
                .Where(f => f.BelongsToUserId == request.UserId)
                .ToListAsync();

            if (favoreds.Count == 0)
                throw new NotFoundException(request.UserId);

            foreach(var favored in favoreds)
            {
                var fav = FavoredsByUserIdModel.Create(favored);

                var account = await _context.FavoredHasAccount
                    .Where(fha => fha.FavoredId == favored.Id)
                    .Select(fha => fha.Account)
                    .SingleOrDefaultAsync();

                if (account == null)
                    favoredList.Add(fav);

                fav.Account = FavoredsByUserIdAccountModel.Create(account);

                favoredList.Add(fav);
            }

            return favoredList;
        }
    }
}
