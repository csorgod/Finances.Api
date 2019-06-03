using Finances.Core.Application.Favoreds.Commands.CreateFavored;
using Finances.Core.Application.Favoreds.Queries.GetFavoredById;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Finances.Api.Controllers
{
    public class FavoredController : BaseController
    {
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

        [HttpGet("{userId}")]
        public Task<IActionResult> GetByUserId(Guid userId)
        {
            throw new NotImplementedException();
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
