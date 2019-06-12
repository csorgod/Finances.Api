using Finances.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Finances.Infrastructure.Persistence.Configurations
{
    public class UserHasAccountConfiguration : IEntityTypeConfiguration<UserHasAccount>
    {
        public void Configure(EntityTypeBuilder<UserHasAccount> builder)
        {
            builder
                .HasKey(uha => uha.Id);

            builder.Property(uha => uha.Id)
                .HasColumnName("id")
                .HasColumnType("varchar(36)")
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(fha => fha.UserId)
                .HasColumnName("user_id")
                .HasColumnType("varchar(36)")
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(fha => fha.AccountId)
                .HasColumnName("account_id")
                .HasColumnType("varchar(36)")
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(uha => uha.CreatedDate)
                .HasColumnName("created_date")
                .HasColumnType("timestamp")
                .HasDefaultValue(DateTime.Now)
                .IsRequired();

            builder.Property(uha => uha.UpdatedDate)
                .HasColumnName("updated_date")
                .HasColumnType("timestamp")
                .HasDefaultValue(DateTime.Now)
                .IsRequired();
        }
    }
}
