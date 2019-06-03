using Finances.Core.Application.Interfaces;
using Finances.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Finances.Infrastructure.Persistence.DatabaseContext
{
    public class FinancesDbContext : DbContext, IFinancesDbContext
    {
        public FinancesDbContext(DbContextOptions<FinancesDbContext> options) : base(options) { }

        public DbSet<Person> Person { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserHasPerson> UserHasPerson { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<PersonHasContact> PersonHasContact { get; set; }
        public DbSet<LoginJwt> LoginJwt { get; set; }
        public DbSet<UserImage> UserImage { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<Favored> Favored { get; set; }
        public DbSet<FavoredHasAccount> FavoredHasAccount { get; set; }
        public DbSet<UserHasAccount> UserHasAccount { get; set; }
        public DbSet<Incoming> Incoming { get; set; }
        
    }
}
