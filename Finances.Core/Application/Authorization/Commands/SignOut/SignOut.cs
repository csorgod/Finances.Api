using Finances.Common.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Core.Application.Authorization.Commands.SignOut
{
    public class SignOut : IRequest<JsonDefaultResponse>
    {
        public string Username { get; set; }
    }
}
