﻿using Finances.Common.Data;
using Finances.Core.Application.Users.Queries.GetProfileByUserId;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Finances.Api.Controllers
{
    public class UserController : BaseController
    {
        public UserController(IOptions<AppSettings> appSettings) : base(appSettings)
        {
        }

        [HttpGet("ProfileByUserId")]
        public async Task<IActionResult> ProfileByUserId()
        {
            var response = await Mediator.Send(new ProfileByUserId { UserId = UserLogged.UserId });

            if (response.Success)
                return StatusCode(200, response);

            return StatusCode(500, response);
        }
    }
}