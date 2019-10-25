using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Finances.Common.Data;
using Finances.Core.Application.Interfaces;
using MediatR;
using static Finances.Common.Helpers.Enum;

namespace Finances.Core.Application.JwtManager.Commands.CancelToken
{
    public class CancelTokenHandler : IRequestHandler<CancelToken, JsonDefaultResponse>
    {
        private readonly IFinancesDbContext _context;
        private readonly IMediator _mediator;

        public CancelTokenHandler(IFinancesDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<JsonDefaultResponse> HandleAsync(CancelToken request, CancellationToken cancellationToken)
        {
            try
            {
                var jwt = _context.LoginJwt
                .Where(j => j.Id == request.Token && j.Status == Status.Active)
                .SingleOrDefault();

                if (jwt == null)
                    return new JsonDefaultResponse
                    {
                        Success = false,
                        Message = "O token informado não existe ou já foi cancelado."
                    };
                
                jwt.Status = Status.Inactive;
                jwt.ExpireDate = DateTime.Now;

                _context.LoginJwt.Add(jwt);
                await _context.SaveChangesAsync(cancellationToken);

                await _mediator.Publish(new TokenCanceled { Id = jwt.Id }, cancellationToken);

                return new JsonDefaultResponse
                {
                    Success = true,
                    Message = "Token cancelado com sucesso."
                };
            }
            catch (Exception ex)
            {
                return new JsonDefaultResponse
                {
                    Success = false,
                    Message = "Houve um erro ao cancelar o token: " + ex.Message
                 };
            }
        }
    }
}
