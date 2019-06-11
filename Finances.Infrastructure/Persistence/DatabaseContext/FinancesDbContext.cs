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
        public DbSet<Card> Card { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FinancesDbContext).Assembly);
            
            #region Table references

            modelBuilder
                .Entity<Person>()
                .ToTable("person", schema: "finances")
                .HasIndex(p => p.TaxNumber)
                .IsUnique();

            modelBuilder
                .Entity<User>()
                .ToTable("user", schema: "finances")
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder
                .Entity<UserHasPerson>()
                .ToTable("user_has_person", schema: "finances");

            modelBuilder
                .Entity<Contact>()
                .ToTable("contact", schema: "finances")
                .HasIndex(c => c.Email)
                .IsUnique();

            modelBuilder
                .Entity<PersonHasContact>()
                .ToTable("person_has_contact", schema: "finances");

            modelBuilder
                .Entity<LoginJwt>()
                .ToTable("login_jwt", schema: "finances");

            modelBuilder
                .Entity<UserImage>()
                .ToTable("user_image", schema: "finances");

            modelBuilder
                .Entity<Account>()
                .ToTable("account", schema: "finances");

            modelBuilder
                .Entity<Favored>()
                .ToTable("favored", schema: "finances");

            #region FavoredHasAccount

            modelBuilder
                .Entity<FavoredHasAccount>()
                .ToTable("favored_has_account", schema: "finances");

            modelBuilder.Entity<FavoredHasAccount>()
                .HasKey(fha => new { fha.AccountId, fha.FavoredId });

            modelBuilder.Entity<FavoredHasAccount>()
                .HasOne(fha => fha.Account);

            #endregion

            modelBuilder
                .Entity<UserHasAccount>()
                .ToTable("user_has_account", schema: "finances");

            modelBuilder
                .Entity<Incoming>()
                .ToTable("incoming", schema: "finances");

            modelBuilder
                .Entity<Card>()
                .ToTable("card", schema: "finances");

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
