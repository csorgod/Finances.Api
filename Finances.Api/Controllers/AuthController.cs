using Finances.Common.Data;
using Finances.Core.Application.Authorization.Commands.CreateAccount;
using Finances.Core.Application.Authorization.Commands.SignIn;
using Finances.Core.Application.Authorization.Commands.SignOut;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Finances.Api.Controllers
{
    public class AuthController : BaseController
    {
        public AuthController(IOptions<AppSettings> appSettings) : base(appSettings) { }
                
        [AllowAnonymous, HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]SignIn loginData)
        {
            var response = await Mediator.Send(loginData);

            if (response.Success)
                return StatusCode(200, response);

            return StatusCode(500, response);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody]SignOut loginData)
        {
            var response = await Mediator.Send(loginData);

            if (response.Success)
                return StatusCode(200, response);

            return StatusCode(500, response);
        }

        [AllowAnonymous, HttpPost("CreateAccount")]
        public async Task<IActionResult> CreateAccount([FromBody]SignUp newAccount)
        {
            var response = await Mediator.Send(newAccount);

            if (response.Success)
                return StatusCode(200, response);

            return StatusCode(500, response);
        }
    }
}