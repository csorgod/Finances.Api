using Finances.Common.Data;
using MediatR;

namespace Finances.Core.Application.Authorization.Commands.SignIn
{
    public class SignInRequest : IRequest<JsonDefaultResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
