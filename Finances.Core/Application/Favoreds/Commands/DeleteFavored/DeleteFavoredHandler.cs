using Finances.Common.Data;
using Finances.Core.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Finances.Common.Helpers.Enum;

namespace Finances.Core.Application.Favoreds.Commands.DeleteFavored
{
    public class DeleteFavoredHandler : IRequestHandler<DeleteFavored, JsonDefaultResponse>
    {
        private readonly IFinancesDbContext _context;
        private readonly IMediator _mediator;

        public DeleteFavoredHandler(IFinancesDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<JsonDefaultResponse> HandleAsync(DeleteFavored request, CancellationToken cancellationToken)
        {
            try
            {
                var favoredToDelete = await _context.Favored
                .Where(f => f.Id == request.Id && f.Status == Status.Active)
                .SingleOrDefaultAsync();

                if (favoredToDelete == null)
                    return new JsonDefaultResponse
                    {
                        Success = false,
                        Message = "Favorecido não encontrado."
                    };

                var hasAccount = await _context.FavoredHasAccount
                .Where(f => f.FavoredId == favoredToDelete.Id)
                .SingleOrDefaultAsync();

                if (hasAccount != null)
                {
                    var accountToDelete = await _context.Account
                    .Where(a => a.Id == hasAccount.AccountId && a.Status == Status.Active)
                    .SingleOrDefaultAsync();

                    accountToDelete.Status = Status.Inactive;
                    //accountToDelete.updated_date = DateTime.Now; TODO: Validar a data de cancelamento
                    _context.Account.Update(accountToDelete);
                }

                favoredToDelete.Status = Status.Inactive;
                //favoredToDelete.UpdatedDate = DateTime.Now; TODO: Validar a data de cancelamento
                _context.Favored.Update(favoredToDelete);
                await _context.SaveChangesAsync(cancellationToken);

                return new JsonDefaultResponse
                {
                    Success = true,
                    Message = "Favorecido excluído com sucesso."
                };
            }
            catch (Exception ex)
            {
                return new JsonDefaultResponse
                {
                    Success = false,
                    Message = "Houve um erro ao excluir o favorecido: " + ex.Message
                };
            }
        }
    }
}
