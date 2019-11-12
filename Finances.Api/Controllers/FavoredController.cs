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
            return Ok(await Mediator.Send(new FavoredById { Id = id }));
        }

        [HttpGet("ByUserId")]
        public async Task<IActionResult> GetByUserId()
        {
            return Ok(await Mediator.Send(new FavoredsByUserId { UserId = UserLogged.UserId }));
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateFavored value)
        {
            return Ok(await Mediator.Send(value));
        }
        
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteFavored { Id = id }));
        }
    }
}
