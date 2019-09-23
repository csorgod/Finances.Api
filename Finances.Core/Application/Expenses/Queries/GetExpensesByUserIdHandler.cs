using Finances.Common.Data;
using Finances.Core.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Finances.Common.Helpers.Enum;

namespace Finances.Core.Application.Expenses.Queries.GetExpensesByUserId
{
    public class GetExpensesByUserIdHandler : IRequestHandler<GetExpensesByUserIdRequest, GetExpensesByUserIdResponse>
    {
        private readonly IFinancesDbContext _context;

        public GetExpensesByUserIdHandler(IFinancesDbContext context)
        {
            _context = context;
        }

        public async Task<GetExpensesByUserIdResponse> Handle(GetExpensesByUserIdRequest request, CancellationToken cancellationToken)
        {
            var userHasPerson = await _context.UserHasPerson
                .Where(uhp => uhp.UserId == request.UserId)
                .SingleOrDefaultAsync();

            if (userHasPerson == null)
                return new GetExpensesByUserIdResponse { Success = false, Message = "Seu usuário não foi encontrado" };

            var expenses = await _context.Expense
                .Where(e => e.PersonId == userHasPerson.PersonId)
                .Select(e => ExpensesByUserIdModel.Create(e))
                .ToListAsync();

            return new GetExpensesByUserIdResponse { Expenses = expenses };
        }
    }
}
