using Finances.Common.Data;
using Finances.Common.Helpers;
using Finances.Common.Session;
using Finances.Core.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Finances.Common.Helpers.Enum;

namespace Finances.Core.Application.Authorization.Commands.SignIn
{
    public class SignInHandler : IRequestHandler<SignIn, JsonDefaultResponse>
    {
        private readonly IFinancesDbContext _context;
        private readonly IMediator _mediator;
        private readonly CryptoHelper cryptoHelper;
        private readonly AppSettings Configuration;

        public SignInHandler(IFinancesDbContext context, IMediator mediator, IOptions<AppSettings> configuration)
        {
            _context = context;
            _mediator = mediator;
            Configuration = configuration.Value;
            cryptoHelper = new CryptoHelper();
        }

        public async Task<JsonDefaultResponse> Handle(SignIn request, CancellationToken cancellationToken)
        {
            var login = await _context.User
                .Where(u => u.Username == request.Username)
                .SingleOrDefaultAsync();

            if (login == null)
                return new JsonDefaultResponse
                {
                    Success = false,
                    Message = "Login e/ou senha incorretos."
                };

            if (!cryptoHelper.IsValid(request.Password, login.Password))
                return new JsonDefaultResponse
                {
                    Success = false,
                    Message = "A senha informada está incorreta."
                };

            if (login.Status != Status.Active)
                return new JsonDefaultResponse
                {
                    Success = false,
                    Message = "Esse usuário não possui permissão de acesso."
                };

            var viewModel = new LoginJwt
            {
                UserId = login.Id,
                Validation = Guid.NewGuid().ToString(),
                ExpireDate = DateTime.Now.AddDays(1),
                LoginBy = LoginMode.App
            };

            Common.Helpers.JwtManager jwtManager = new Common.Helpers.JwtManager(Configuration);

            string tokenJWT = jwtManager.GenerateToken(viewModel);

            #region Saving JWT in the Database

            var oldJWT = await _context.LoginJwt
            .Where(j => j.UserId == viewModel.UserId && j.Status == Status.Active && j.ExpireDate > DateTime.Now)
            .SingleOrDefaultAsync();

            if (oldJWT != null)
            {
                oldJWT.Status = Status.Inactive;
                //oldJWT.UpdatedDate = DateTime.Now; -- Verificar se a data está correta
                _context.Entry(oldJWT).State = EntityState.Modified;
                await _context.SaveChangesAsync(cancellationToken);
            }

            string[] tokenSplitted = tokenJWT.Split('.');
            var jwt = new Domain.Entities.LoginJwt
            {
                UserId = viewModel.UserId,
                Header = tokenSplitted[0],
                Payload = tokenSplitted[1],
                Signature = tokenSplitted[2],
                Status = Status.Active,
                ExpireDate = viewModel.ExpireDate
            };

            try
            {
                _context.LoginJwt.Add(jwt);
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch
            {
                return new JsonDefaultResponse
                {
                    Success = false,
                    Message = "Houve um erro ao salvar o token de autenticação."
                };
            }

            #endregion
            
            await _mediator.Publish(new UserAuthenticated { Id = viewModel.UserId }, cancellationToken);

            var person = await _context.UserHasPerson
            .Where(uhp => uhp.UserId == login.Id)
            .Select(uhp => uhp.Person)
            .SingleOrDefaultAsync();

            var contact = await _context.PersonHasContact
            .Where(phc => phc.PersonId == person.Id)
            .Select(phc => phc.Contact)
            .SingleOrDefaultAsync();

            return new JsonDefaultResponse
            {
                Success = true,
                Message = "Login autorizado.",
                Payload = new UserAuth
                {
                    JwtToken = tokenJWT,
                    User = new UserData
                    {
                        Id = login.Id,
                        Username = login.Username,
                        Name = person.FirstName,
                        LastName = person.LastName,
                        PhoneNumber = contact.PhoneNumber,
                        Email = contact.Email
                    }
                }
            };
        }
    }
}
