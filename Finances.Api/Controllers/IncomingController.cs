using Finances.Common.Data;
using Finances.Core.Application.Incomings.Commands.CreateIncoming;
using Finances.Core.Application.Incomings.Queries.GetIncomingsByUserId;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Finances.Api.Controllers
{
    public class IncomingController : BaseController
    {
        public IncomingController(IOptions<AppSettings> appSettings) : base(appSettings) { }

        [HttpGet]
        public async Task<IActionResult> GetByUserId()
        {
            var result = await Mediator.Send(new GetIncomingsByUserId { UserId = UserLogged.UserId });
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateIncoming value)
        {
            var result = await Mediator.Send(value);
            return StatusCode(result.StatusCode, result);
        }
    }
}