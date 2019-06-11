using Finances.Common.Data;
using Finances.Core.Application.Favoreds.Commands.CreateFavored;
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

        [HttpGet]
        public Task<ActionResult<IEnumerable<string>>> GetAsync()
        {
            throw new NotImplementedException();
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await Mediator.Send(new GetFavoredById { Id = id }));
        }

        [HttpGet("ByUserId/{userId}")]
        public async Task<IActionResult> GetByUserId(Guid userId)
        {
            return Ok(await Mediator.Send(new GetFavoredsByUserId { UserId = userId }));
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateFavored value)
        {
            return Ok(await Mediator.Send(value));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
