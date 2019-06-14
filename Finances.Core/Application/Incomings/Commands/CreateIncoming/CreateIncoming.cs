using Finances.Common.Data;
using MediatR;
using System;
using static Finances.Common.Helpers.Enum;

namespace Finances.Core.Application.Incomings.Commands.CreateIncoming
{
    public class CreateIncoming : IRequest<JsonDefaultResponse>
    {
        public Guid PersonId { get; set; }
        public Guid UserId { get; set; }
        public IncomeType IncomeType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public DateTime ReceiveAt { get; set; }
        public bool Recurrent { get; set; }
    }
}
