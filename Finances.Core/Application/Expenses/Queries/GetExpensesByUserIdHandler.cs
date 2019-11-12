using Finances.Common.Data;
using Finances.Core.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Finances.Core.Application.Expenses.Queries.GetExpensesByUserId
{
    public class GetExpensesByUserIdHandler : IRequestHandler<ExpensesByUserId, JsonDefaultResponse>
    {
        private readonly IFinancesDbContext _context;
        
        public GetExpensesByUserIdHandler(IFinancesDbContext context)
        {
            _context = context;
        }

        public async Task<JsonDefaultResponse> Handle(ExpensesByUserId request, CancellationToken cancellationToken)
        {
            var userHasPerson = await _context.UserHasPerson
                .Where(uhp => uhp.UserId == request.UserId)
                .SingleOrDefaultAsync();

            if (userHasPerson == null)
                return new JsonDefaultResponse
                {
                    Success = false,
                    Message = "O usuário não possui uma pessoa vinculada"
                };

            var expenses = await _context.Expense
                .Where(e => e.PersonId == userHasPerson.PersonId)
                .Select(e => ExpensesByUserIdModel.Create(e))
                .ToListAsync();

            return new JsonDefaultResponse
            {
                Success = true,
                Payload = expenses
            };
        }
    }
}
