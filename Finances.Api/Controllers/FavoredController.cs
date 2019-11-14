using Finances.Common.Data;
using Finances.Core.Application.Favoreds.Commands.CreateFavored;
using Finances.Core.Application.Favoreds.Commands.DeleteFavored;
using Finances.Core.Application.Favoreds.Queries.GetFavoredById;
using Finances.Core.Application.Favoreds.Queries.GetFavoredsByUserId;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Finances.Api.Controllers
{
    public class FavoredController : BaseController
    {
        public FavoredController(IOptions<AppSettings> appSettings) : base(appSettings) { }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = await Mediator.Send(new FavoredById { Id = id });

            if (response.Success)
                return StatusCode(200, response);

            return StatusCode(500, response);
        }

        [HttpGet("ByUserId")]
        public async Task<IActionResult> GetByUserId()
        {
            var response = await Mediator.Send(new FavoredsByUserId { UserId = UserLogged.UserId });

            if (response.Success)
                return StatusCode(200, response);

            return StatusCode(500, response);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateFavored value)
        {
            var response = await Mediator.Send(value);

            if (response.Success)
                return StatusCode(200, response);

            return StatusCode(500, response);
        }
        
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await Mediator.Send(new DeleteFavored { Id = id });

            if (response.Success)
                return StatusCode(200, response);

            return StatusCode(500, response);
        }
    }
}
