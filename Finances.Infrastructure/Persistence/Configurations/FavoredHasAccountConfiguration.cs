using Finances.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Infrastructure.Persistence.Configurations
{
    public class FavoredHasAccountConfiguration : IEntityTypeConfiguration<FavoredHasAccount>
    {
        public void Configure(EntityTypeBuilder<FavoredHasAccount> builder)
        {
            builder
               .HasKey(fha => fha.Id);

            builder.Property(fha => fha.Id)
                .HasColumnName("id")
                .HasColumnType("varchar(36)")
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(fha => fha.AccountId)
                .HasColumnName("account_id")
                .HasColumnType("varchar(36)")
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(fha => fha.FavoredId)
                .HasColumnName("favored_id")
                .HasColumnType("varchar(36)")
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(fha => fha.CreatedDate)
                .HasColumnName("created_date")
                .HasColumnType("timestamp")
                .IsRequired();

            builder.Property(fha => fha.UpdatedDate)
                .HasColumnName("updated_date")
                .HasColumnType("timestamp")
                .IsRequired();

        }
    }
}
