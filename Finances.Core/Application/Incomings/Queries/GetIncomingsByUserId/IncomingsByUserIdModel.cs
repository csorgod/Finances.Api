using Finances.Core.Domain.Entities;
using System;
using System.Linq.Expressions;
using static Finances.Common.Helpers.Enum;

namespace Finances.Core.Application.Incomings.Queries.GetIncomingsByUserId
{
    public class IncomingsByUserIdModel
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public Guid UserId { get; set; }
        public IncomeType IncomeType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public DateTime ReceiveAt { get; set; }
        public bool Recurrent { get; set; }

        public static Expression<Func<Incoming, IncomingsByUserIdModel>> Projection
        {
            get
            {
                return incoming => new IncomingsByUserIdModel
                {
                    Id = incoming.Id,
                    PersonId = incoming.PersonId,
                    IncomeType = incoming.IncomeType,
                    Name = incoming.Name,
                    Description = incoming.Description,
                    Value = incoming.Value,
                    ReceiveAt = incoming.ReceiveAt,
                    Recurrent = incoming.Recurrent
                };
            }
        }

        public static IncomingsByUserIdModel Create(Incoming incoming)
            => Projection.Compile().Invoke(incoming);
    }
}
