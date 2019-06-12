using Finances.Common.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Core.Application.JwtManager.Commands.CancelToken
{
    public class CancelToken : IRequest<JsonDefaultResponse>
    {
        public Guid Token { get; set; }
    }
}
