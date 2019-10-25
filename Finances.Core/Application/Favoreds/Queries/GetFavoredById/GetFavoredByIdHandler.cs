using Finances.Common.Data;
using Finances.Core.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Finances.Core.Application.Favoreds.Queries.GetFavoredById
{
    public class GetFavoredByIdHandler : IRequestHandler<GetFavoredById, JsonDefaultResponse>
    {
        private readonly IFinancesDbContext _context;

        public GetFavoredByIdHandler(IFinancesDbContext context)
        {
            _context = context;
        }

        public async Task<JsonDefaultResponse> HandleAsync(GetFavoredById request, CancellationToken cancellationToken)
        {
            var favored = await _context.Favored
                .FindAsync(request.Id);

            if(favored == null)
                return new JsonDefaultResponse
                {
                    Success = true,
                    Message = "Nenhum favorecido encontrado"
                };

            var fav = FavoredByIdModel.Create(favored);

            var account = await _context.FavoredHasAccount
                .Where(fha => fha.FavoredId == favored.Id)
                .Select(fha => fha.Account)
                .SingleOrDefaultAsync();
            
            if (account != null)
                fav.Account = FavoredByIdAccountModel.Create(account);

            return new JsonDefaultResponse
            {
                Success = true,
                Payload = fav
            };
        }
    }
}
