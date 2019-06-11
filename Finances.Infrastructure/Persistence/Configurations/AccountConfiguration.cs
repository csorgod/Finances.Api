using Finances.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Finances.Infrastructure.Persistence.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .HasColumnName("id")
                .HasColumnType("varchar(36)")
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(a => a.Bank)
                .HasColumnName("bank")
                .HasColumnType("int(6)")
                .HasMaxLength(6)
                .IsRequired();

            builder.Property(a => a.BankBranch)
                .HasColumnName("bank_branch")
                .HasColumnType("int(4)")
                .HasMaxLength(4)
                .IsRequired();

            builder.Property(a => a.BankAccount)
                .HasColumnName("bank_branch")
                .HasColumnType("int(4)")
                .HasMaxLength(4)
                .IsRequired();

            builder.Property(a => a.BankAccountDigit)
                .HasColumnName("bank_account_digit")
                .HasColumnType("int(2)")
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(a => a.Status)
                .HasColumnName("status")
                .HasColumnType("int(1)")
                .HasMaxLength(1)
                .IsRequired();

            builder.Property(a => a.Status)
                .HasColumnName("status")
                .HasColumnType("int(1)")
                .HasMaxLength(1)
                .IsRequired();

            builder.Property(a => a.AccountType)
                .HasColumnName("account_type")
                .HasColumnType("int(1)")
                .HasMaxLength(1)
                .IsRequired();

            builder.Property(a => a.CreatedDate)
                .HasColumnName("created_date")
                .HasColumnType("timestamp")
                .HasDefaultValue(DateTime.Now)
                .IsRequired();

            builder.Property(a => a.UpdatedDate)
                .HasColumnName("updated_date")
                .HasColumnType("timestamp")
                .HasDefaultValue(DateTime.Now)
                .IsRequired();
        }
    }
}
