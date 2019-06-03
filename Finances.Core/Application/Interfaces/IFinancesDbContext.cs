using Finances.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Finances.Core.Application.Interfaces
{
    public interface IFinancesDbContext
    {
        DbSet<Person> Person { get; set; }
        DbSet<User> User { get; set; }
        DbSet<UserHasPerson> UserHasPerson { get; set; }
        DbSet<Contact> Contact { get; set; }
        DbSet<PersonHasContact> PersonHasContact { get; set; }
        DbSet<LoginJwt> LoginJwt { get; set; }
        DbSet<UserImage> UserImage { get; set; }
        DbSet<Account> Account { get; set; }
        DbSet<Favored> Favored { get; set; }
        DbSet<FavoredHasAccount> FavoredHasAccount { get; set; }
        DbSet<UserHasAccount> UserHasAccount { get; set; }
        DbSet<Incoming> Incoming { get; set; }
        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
