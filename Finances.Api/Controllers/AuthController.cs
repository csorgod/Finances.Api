using Finances.Common.Data;
using Finances.Core.Application.Accounts.Commands;
using Finances.Core.Application.Authorization.Commands.SignIn;
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

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn([FromBody]SignIn loginData)
        {
            return Ok(await Mediator.Send(loginData));
        }

        public async Task<IActionResult> CreateAccount([FromBody]CreateAccount newAccount)
        {
            return Ok(await Mediator.Send(newAccount));
        }
    }
}