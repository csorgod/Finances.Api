using Finances.Common.Data;
using Finances.Core.Application.Accounts.Commands;
using MediatR;
using System;

namespace Finances.Core.Application.Favoreds.Commands.CreateFavored
{
    public class CreateFavored : IRequest<JsonDefaultResponse>
    {
        public string Name { get; set; }
        public Guid BelongToUserId { get; set; }
        public string TaxNumber { get; set; }        
        public DateTime CreatedAt { get; set; }
        public CreateAccount Account { get; set; }
    }
}
