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
            return Ok(await Mediator.Send(new GetIncomingsByUserId { UserId = UserLogged.UserId }));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateIncoming value)
        {
            return Ok(await Mediator.Send(value));
        }
    }
}