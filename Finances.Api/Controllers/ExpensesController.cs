using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoMapper;

using Finances.Core.Application.Expenses.Queries.GetExpensesByUserId;

namespace Finances.Api.Controllers
{
    public class ExpenseController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetExpensesByUserId() 
        {
            var result = await Mediator.Send(new GetExpensesByUserId { UserId = UserLogged.UserId });
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExpense()
        {
            return NoContent();
        }
    }
}