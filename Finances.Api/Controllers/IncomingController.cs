using AutoMapper;
using Finances.Core.Application.Incomings.Commands.CreateIncoming;
using Finances.Core.Application.Incomings.Queries.GetIncomingsByUserId;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Finances.Api.Controllers
{
    public class IncomingController : BaseController
    {
        public IncomingController(IMapper mapper) : base(mapper) { }

        [HttpGet]
        public async Task<IActionResult> GetIncomingsByUserId()
        {
            var response = await Mediator.Send(new IncomingsByUserId { UserId = UserLogged.UserId });

            if (response.Success)
                return StatusCode(200, response);

            return StatusCode(500, response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateIncoming value)
        {
            var response = await Mediator.Send(value);

            if (response.Success)
                return StatusCode(200, response);

            return StatusCode(500, response);

        }
    }
}