using Finances.Common.Data;
using Finances.Common.Helpers;
using Finances.Core.Application.Interfaces;
using Finances.Core.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Finances.Common.Helpers.Enum;
using Resx = Finances.Common.Resources;

namespace Finances.Core.Application.Authorization.Commands.CreateAccount
{
    public class CreateAccountHandler : IRequestHandler<SignUp, JsonDefaultResponse>
    {
        private readonly IFinancesDbContext _context;
        private readonly IMediator _mediator;
        private readonly CryptoHelper _cryptoHelper;

        public CreateAccountHandler(IFinancesDbContext context, IMediator mediator, CryptoHelper cryptoHelper)
        {
            _context = context;
            _mediator = mediator;
            _cryptoHelper = cryptoHelper;
        }

        public async Task<JsonDefaultResponse> Handle(SignUp request, CancellationToken cancellationToken)
        {
            try
            {
                var existentUser = await _context.User
                .Where(u => u.Username == request.Username)
                .SingleOrDefaultAsync();

                if (existentUser != null)
                    return new JsonDefaultResponse
                    {
                        Success = false,
                        Message = Resx.Strings.ErrorUserAlreadyExists
                    };
            }
            catch (Exception ex)
            {
                return new JsonDefaultResponse
                {
                    Success = false,
                    Message = string.Format($"{Resx.Strings.ErrorSearchingForUsers}: {ex.Message}.")
                };
            }
            
            var user = new User
            {
                Username = request.Username,
                Password = _cryptoHelper.Encrypt(request.Password),
                Status = Status.Active
            };

            var person = new Person
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                BirthDate = request.BirthDate,
                TaxNumber = request.TaxNumber,
                Gender = request.Gender
            };

            var userHasPerson = new UserHasPerson
            {
                UserId = user.Id,
                PersonId = person.Id
            };

            var contact = new Contact
            {
                PhoneNumber = request.PhoneNumber,
                Email = request.Email
            };

            var personHasContact = new PersonHasContact
            {
                PersonId = person.Id,
                ContactId = contact.Id
            };

            var userImage = new UserImage
            {
                UserId = user.Id,
                Path = request.ImagePath
            };

            try
            {
                _context.User.Add(user);
                _context.Person.Add(person);
                _context.UserHasPerson.Add(userHasPerson);
                _context.Contact.Add(contact);
                _context.PersonHasContact.Add(personHasContact);
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                return new JsonDefaultResponse
                {
                    Success = false,
                    Message = string.Format($"{Resx.Strings.ErrorCreatingAccount}: {ex.Message}.") 
                };
            }

            return new JsonDefaultResponse
            {
                Success = true,
                Message = Resx.Strings.SuccessAccountCreation
            };
        }
    }
}
