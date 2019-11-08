using System;
using System.Linq;
using System.Threading.Tasks;
using Finances.Common.Data;
using Finances.Common.Session;

using AutoMapper;
using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using static Finances.Common.Helpers.Enum;
using Finances.Core.Application.Authorization.Commands.SignOut;
using System.Net;

namespace Finances.Api.Controllers
{
    [Authorize, ApiController, Route("[controller]")]
    public abstract class BaseController : Controller
    {
        protected LoginJwt UserLogged;

        private IMediator _mediator;
        protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());

        private IOptions<AppSettings> AppSettings;

        protected IMapper Mapper;

        public BaseController() {}
        public BaseController(IMapper mapper) { Mapper = mapper; }
        public BaseController(IOptions<AppSettings> appSettings) { AppSettings = appSettings; }

        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var allow = context.Controller
                .GetType()
                .GetMethod(ControllerContext.ActionDescriptor.ActionName)
                .GetCustomAttributes(typeof(AllowAnonymousAttribute), true)
                .ToList();

            if (allow.Count() == 0)
            {
                UserLogged = new LoginJwt
                {
                    UserId = Guid.Parse(HttpContext.User.Claims.Where(c => c.Type == "UserId").FirstOrDefault().Value),
                    Validation = HttpContext.User.Claims.Where(c => c.Type == "Validation").SingleOrDefault().Value.ToString(),
                    ExpireDate = Convert.ToDateTime(HttpContext.User.Claims.Where(c => c.Type == "ExpireDate").SingleOrDefault().Value.Split('.')[0].Replace("\"", "")),
                    LoginBy = (LoginMode)Convert.ToInt32(HttpContext.User.Claims.Where(c => c.Type == "LoginBy").SingleOrDefault().Value)
                };

                if (UserLogged.ExpireDate <= DateTime.Now)
                {
                    //context.Result = StatusCode(403);
                }
                    
            }

            return base.OnActionExecutionAsync(context, next);
        }

    }
}