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

namespace Finances.Core.Application.Expenses.Queries.GetExpensesByUserId
{
    public class GetExpensesByUserIdHandler : IRequestHandler<GetExpensesByUserIdRequest, GetExpensesByUserIdResponse>
    {
        private readonly IFinancesDbContext _context;
        private UserHasPerson userHasPerson;
        public GetExpensesByUserIdHandler(IFinancesDbContext context)
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

        private GetExpensesByUserIdResponse FailResponse(string message, int statusCode)
        {
            return new GetExpensesByUserIdResponse
            {
                Success = false,
                StatusCode = statusCode,
                Message = message
            };
        }

        public async Task<GetExpensesByUserIdResponse> HandleAsync(GetExpensesByUserIdRequest request, CancellationToken cancellationToken)
        {
            if (await UserNotFound(request.UserId))
                return FailResponse($"O usuário com id {request.UserId} não foi encontrado", 400);

            var expenses = await _context.Expense
                .Where(e => e.PersonId == userHasPerson.PersonId)
                .Select(e => ExpensesByUserIdModel.Create(e))
                .ToListAsync();

            return new GetExpensesByUserIdResponse { Expenses = expenses };
        }
    }
}
