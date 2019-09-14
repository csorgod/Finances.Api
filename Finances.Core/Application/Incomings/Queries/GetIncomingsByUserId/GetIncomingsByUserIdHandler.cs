using Finances.Common.Data;
using Finances.Core.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Finances.Common.Helpers.Enum;

namespace Finances.Core.Application.Incomings.Queries.GetIncomingsByUserId
{
    public class GetIncomingsByUserIdHandler : IRequestHandler<GetIncomingsByUserId, JsonDefaultResponse>
    {
        private readonly IFinancesDbContext _context;

        public GetIncomingsByUserIdHandler(IFinancesDbContext context)
        {
            _context = context;
        }

        public async Task<JsonDefaultResponse> Handle(GetIncomingsByUserId request, CancellationToken cancellationToken)
        {
            var userHasPerson = await _context.UserHasPerson
                .Where(uhp => uhp.UserId == request.UserId)
                .SingleOrDefaultAsync();

            if (userHasPerson == null)
                return new JsonDefaultResponse
                {
                    Success = false,
                    Message = "Seu usuário não foi encontrado"
                };

            var incomings = await _context.Incoming
                .Where(i => i.PersonId == userHasPerson.PersonId && i.Status == Status.Active)
                .Select(i => IncomingsByUserIdModel.Create(i))
                .ToListAsync();

            return new JsonDefaultResponse
            {
                Success = true,
                Payload = incomings
            };
        }
    }
}
