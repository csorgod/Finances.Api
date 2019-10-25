using Finances.Common.Data;
using Finances.Core.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Finances.Core.Application.Users.Queries.GetProfileByUserId
{
    public class GetProfileByUserIdHandler : IRequestHandler<GetProfileByUserId, JsonDefaultResponse>
    {
        private readonly IFinancesDbContext _context;

        public GetProfileByUserIdHandler(IFinancesDbContext context)
        {
            _context = context;
        }

        public async Task<JsonDefaultResponse> HandleAsync(GetProfileByUserId request, CancellationToken cancellationToken)
        {
            var profile = new ProfileByUserIdModel();

            var user = await _context.User
            .Where(u => u.Id == request.UserId)
            .SingleOrDefaultAsync();

            if (user == null)
                new JsonDefaultResponse
                {
                    Success = false,
                    Message = "Nenhum usuário encontrado"
                };

            else
            {
                profile.UserName = user.Username;
                profile.Password = user.Password;
            }

            var person = await _context.UserHasPerson
            .Where(uhp => uhp.UserId == user.Id)
            .Select(uhp => uhp.Person)
            .SingleOrDefaultAsync();

            if (person == null)
                new JsonDefaultResponse
                {
                    Success = false,
                    Message = "Nenhuma pessoa vinculada ao usuário encontrada."
                };

            else
            {
                profile.FirstName = person.FirstName;
                profile.LastName = person.LastName;
                profile.Age = person.Age;
                profile.TaxNumber = person.TaxNumber;
                profile.Gender = person.Gender;
            }

            var userImage = await _context.UserImage
            .Where(ui => ui.UserId == user.Id)
            .SingleOrDefaultAsync();
            
            if (userImage != null)
                profile.UserImage = userImage.Path;
            else
                profile.UserImage = "";

            var contact = await _context.PersonHasContact
            .Where(phc => phc.PersonId == person.Id)
            .Select(phc => phc.Contact)
            .SingleOrDefaultAsync();

            if (contact == null)
                return new JsonDefaultResponse
                {
                    Success = false,
                    Message = "Nenhuma informação de contato encontrada."
                };

            else
            {
                profile.PhoneNumber = contact.PhoneNumber;
                profile.Email = contact.Email;
            }

            return new JsonDefaultResponse
            {
                Success = true,
                Payload = profile
            };
        }
    }
}
