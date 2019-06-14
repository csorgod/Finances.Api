using Finances.Common.Data;
using Finances.Core.Application.Interfaces;
using Finances.Core.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Finances.Common.Helpers.Enum;

namespace Finances.Core.Application.Incomings.Commands.CreateIncoming
{
    public class CreateIncomingHandler : IRequestHandler<CreateIncoming, JsonDefaultResponse>
    {
        private readonly IFinancesDbContext _context;
        private readonly IMediator _mediator;

        public CreateIncomingHandler(IFinancesDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<JsonDefaultResponse> Handle(CreateIncoming request, CancellationToken cancellationToken)
        {
            try
            {
                var person = await _context.UserHasPerson
                .Where(uhp => uhp.UserId == request.UserId)
                .SingleOrDefaultAsync();

                if (person == null)
                    return new JsonDefaultResponse
                    {
                        Success = false,
                        Message = "Seu usuário não foi encontrado"
                    };

                var incoming = new Incoming
                {
                    PersonId = person.Id,
                    IncomeType = request.IncomeType,
                    Name = request.Name,
                    Description = request.Description,
                    Value = request.Value,
                    Status = Status.Active,
                    ReceiveAt = request.ReceiveAt,
                    Recurrent = request.Recurrent
                };

                _context.Incoming.Add(incoming);
                await _context.SaveChangesAsync(cancellationToken);

                return new JsonDefaultResponse
                {
                    Success = true,
                    Message = "Renda cadastrada com sucesso!"
                };
            }
            catch
            {
                return new JsonDefaultResponse
                {
                    Success = false,
                    Message = "Algo deu errado no servidor. Por favor, tente novamente mais tarde"
                };
            }
        }
    }
}
