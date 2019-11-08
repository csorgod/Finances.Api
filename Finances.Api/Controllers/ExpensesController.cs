using AutoMapper;
using Finances.Core.Application.Expenses.Queries.GetExpensesByUserId;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Finances.Api.Controllers
{
    public class ExpenseController : BaseController
    {
        public ExpenseController(IMapper mapper) : base(mapper) {}

        [HttpGet]
        public async Task<IActionResult> GetExpensesByUserId() 
        {
            var response = await Mediator.Send(new ExpensesByUserId { UserId = UserLogged.UserId });
                        
            if (response.Errors.Any())
                return StatusCode(500, response);

            return StatusCode(200, response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExpense()
        {
            return NoContent();
        }
    }
}