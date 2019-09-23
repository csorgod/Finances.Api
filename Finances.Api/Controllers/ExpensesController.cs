using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using Finances.Api.DTO.Expenses;
using Finances.Core.Application.Expenses.Queries.GetExpensesByUserId;

namespace Finances.Api.Controllers
{
    public class ExpenseController : BaseController
    {
        public ExpenseController(IMapper mapper) : base(mapper) {}

        [HttpGet]
        public async Task<IActionResult> GetExpensesByUserId() 
        {
            var result = await Mediator.Send(new GetExpensesByUserIdRequest { UserId = UserLogged.UserId });
            
            var expenses = Mapper.Map<IEnumerable<ExpensesByUserIdModel>, IEnumerable<ExpenseDTO>>(result.Expenses);

            return StatusCode(result.StatusCode, new ExpensesDTO(expenses));
        }

        [HttpPost]
        public async Task<IActionResult> CreateExpense()
        {
            return NoContent();
        }
    }
}