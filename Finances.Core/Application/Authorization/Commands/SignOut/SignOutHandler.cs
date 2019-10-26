using Finances.Common.Data;
using Finances.Common.Helpers;
using Finances.Core.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Resx = Finances.Common.Resources;
using static Finances.Common.Helpers.Enum;

namespace Finances.Core.Application.Authorization.Commands.SignOut
{
    public class SignOutHandler : IRequestHandler<SignOut, JsonDefaultResponse>
    {
        private readonly IFinancesDbContext _context;
        private readonly IMediator _mediator;
        private readonly CryptoHelper cryptoHelper;
        private readonly AppSettings Configuration;

        public SignOutHandler(IFinancesDbContext context, IMediator mediator, IOptions<AppSettings> configuration)
        {
            _context = context;
            _mediator = mediator;
            Configuration = configuration.Value;
            cryptoHelper = new CryptoHelper();
        }

        public async Task<JsonDefaultResponse> Handle(SignOut request, CancellationToken cancellationToken)
        {
            var userLogged = await _context.User
                .Where(u => u.Username == request.Username)
                .Where(u => u.Status == Status.Active)
                .SingleOrDefaultAsync();

            if (userLogged == null)
                return new JsonDefaultResponse
                {
                    Success = false,
                    Message = Resx.Strings.ErrorSearchingForUsers
                };

            var tokenInUse = await _context.LoginJwt
                .Where(t => t.UserId == userLogged.Id)
                .Where(t => t.ExpireDate > DateTime.Now)
                .Where(t => t.Status == Status.Active)
                .SingleOrDefaultAsync();

            if (tokenInUse == null)
                return new JsonDefaultResponse
                {
                    Success = false,
                    Message = Resx.Strings.ErrorUserNotLoggedYet
                };

            tokenInUse.Status = Status.Expired;
            tokenInUse.UpdatedDate = DateTime.Now;
            
            try
            {
                _context.Entry(tokenInUse).State = EntityState.Modified;
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch
            {
                return new JsonDefaultResponse
                {
                    Success = false,
                    Message = Resx.Strings.ErrorLoggingOut
                };
            }

            return new JsonDefaultResponse
            {
                Success = true,
                Message = Resx.Strings.SuccessUserLoggedOut
            };
        }

    }
}
