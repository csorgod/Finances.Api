using Finances.Common.Data;
using Finances.Core.Application.Interfaces;
using Finances.Core.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Finances.Common.Helpers.Enum;

namespace Finances.Core.Application.Incomings.Queries.GetIncomingsByUserId
{
    public class GetIncomingsByUserIdHandler : IRequestHandler<GetIncomingsByUserIdRequest, GetIncomingsByUserIdResponse>
    {
        private readonly IFinancesDbContext _context;
        private UserHasPerson userHasPerson;
        public GetIncomingsByUserIdHandler(IFinancesDbContext context)
        {
            _context = context;
        }

        private async Task<bool> UserNotFound(Guid userId)
        {
            userHasPerson = await _context.UserHasPerson
                .Where(uhp => uhp.UserId == userId)
                .SingleOrDefaultAsync();
            return userHasPerson == null;
        }

        private GetIncomingsByUserIdResponse FailResponse(string message, int statusCode)
        {
            return new GetIncomingsByUserIdResponse
            {
                Success = false,
                StatusCode = statusCode,
                Message = message
            };
        }

        public async Task<GetIncomingsByUserIdResponse> Handle(GetIncomingsByUserIdRequest request, CancellationToken cancellationToken)
        {
            if (await UserNotFound(request.UserId))
                return FailResponse($"O usuário com id {request.UserId} não foi encontrado", 400);

            var incomings = await _context.Incoming
                .Where(i => i.PersonId == userHasPerson.PersonId && i.Status == Status.Active)
                .Select(i => IncomingsByUserIdModel.Create(i))
                .ToListAsync();

            return new GetIncomingsByUserIdResponse { Incomings = incomings };
        }
    }
}
