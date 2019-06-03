using Finances.Core.Application.Interfaces;
using Finances.Core.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Finances.Core.Application.Accounts.Commands
{
    class AccountHandler : IRequestHandler<CreateAccount, Unit>
    {
        private readonly IFinancesDbContext _context;
        private readonly IMediator _mediator;

        public AccountHandler(IFinancesDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(CreateAccount request, CancellationToken cancellationToken)
        {
            var entity = new Account
            {
                
            };

            _context.Account.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new EntityCreated { Id = entity.Id }, cancellationToken);

            return Unit.Value;
        }
    }
}
