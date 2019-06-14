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
            var incomingsList = new List<IncomingsByUserIdModel>();

            var person = await _context.UserHasPerson
            .Where(uhp => uhp.UserId == request.UserId)
            .SingleOrDefaultAsync();

            if (person == null)
                return new JsonDefaultResponse
                {
                    Success = false,
                    Message = "Seu usuário não foi encontrado"
                };

            var incomings = await _context.Incoming
            .Where(i => i.PersonId == person.Id && i.Status == Status.Active)
            .ToListAsync();

            foreach(var incoming in incomings)
            {
                var inc = IncomingsByUserIdModel.Create(incoming);
                incomingsList.Add(inc);
            }

            return new JsonDefaultResponse
            {
                Success = true,
                Payload = incomings
            };
        }
    }
}
