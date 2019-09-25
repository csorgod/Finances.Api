using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using Finances.Api.DTO.Incomings;
using Finances.Core.Application.Incomings.Commands.CreateIncoming;
using Finances.Core.Application.Incomings.Queries.GetIncomingsByUserId;

namespace Finances.Api.Controllers
{
    public class IncomingController : BaseController
    {
        public IncomingController(IMapper mapper) : base(mapper) { }

        [HttpGet]
        public async Task<IActionResult> GetIncomingsByUserId()
        {
            var result = await Mediator.Send(new GetIncomingsByUserIdRequest { UserId = UserLogged.UserId });
            var incomings = Mapper.Map<IEnumerable<IncomingsByUserIdModel>, IEnumerable<IncomingDTO>>(result.Incomings);

            return StatusCode(result.StatusCode, new IncomingsDTO(incomings));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateIncoming value)
        {
            var result = await Mediator.Send(value);
            return StatusCode(result.StatusCode, result);
        }
    }
}