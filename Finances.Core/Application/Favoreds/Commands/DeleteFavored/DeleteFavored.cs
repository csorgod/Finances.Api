using Finances.Common.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Core.Application.Favoreds.Commands.DeleteFavored
{
    public class DeleteFavored : IRequest<JsonDefaultResponse>
    {
        public Guid Id { get; set; }
    }
}
