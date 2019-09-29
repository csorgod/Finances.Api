using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Design;

using Finances.Core.Application.Interfaces;
using Finances.Core.Domain.Entities;

namespace Finances.Infrastructure.Persistence.DatabaseContext
{
    public class FinancesDbContext : DbContext, IFinancesDbContext
    {
        private static readonly string ConnectionStringName = "MySqlConnection";
        private static readonly string AspNetCoreEnvironment = "ASPNETCORE_ENVIRONMENT";

        public FinancesDbContext() : base() { }
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
        public DbSet<Expense> Expense { get; set; }
        public DbSet<Card> Card { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var environmentName = Environment.GetEnvironmentVariable(AspNetCoreEnvironment);
            var basePath = Directory.GetCurrentDirectory();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.Local.json", optional: true)
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
           
            var connectionString = configuration.GetConnectionString(ConnectionStringName);
            optionsBuilder.UseMySql(connectionString);
        }
    }
}
