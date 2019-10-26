using Finances.Common.Data;
using Finances.Core.Application.Authorization.Commands.CreateAccount;
using Finances.Core.Application.Authorization.Commands.SignIn;
using Finances.Core.Application.Authorization.Commands.SignOut;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace Finances.Api.Controllers
{
    public class AuthController : BaseController
    {
        public AuthController(IOptions<AppSettings> appSettings) : base(appSettings) { }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]SignIn loginData)
        {
            return Ok(await Mediator.Send(loginData));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Logout([FromBody]SignOut loginData)
        {
            return Ok(await Mediator.Send(loginData));
        }

        [AllowAnonymous]
        [HttpPost("CreateAccount")]
        public async Task<IActionResult> CreateAccount([FromBody]CreateAccount newAccount)
        {
            return Ok(await Mediator.Send(newAccount));
        }
    }
}