using Finances.Common.Data;
using Finances.Common.Helpers;
using Finances.Core.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

        public Task<JsonDefaultResponse> Handle(SignOut request, CancellationToken cancellationToken)
        {
            var userLogged = await _context.LoginJwt
                .Where(u => u.Header == )
        }

    }
}
