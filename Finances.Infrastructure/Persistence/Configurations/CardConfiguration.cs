using Finances.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Finances.Infrastructure.Persistence.Configurations
{
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .HasColumnType("varchar(36)")
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(c => c.PersonId)
                .HasColumnName("person_id")
                .HasColumnType("varchar(36)")
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(c => c.Type)
                .HasColumnName("type")
                .HasColumnType("int(1)")
                .HasMaxLength(1)
                .IsRequired();

            builder.Property(c => c.Holder)
                .HasColumnName("person_id")
                .HasColumnType("varchar(30)")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(c => c.Number)
                .HasColumnName("number")
                .HasColumnType("varchar(16)")
                .HasMaxLength(16)
                .IsRequired();

            builder.Property(c => c.ExpireDate)
                .HasColumnName("expire_date")
                .HasColumnType("timestamp")
                .IsRequired();

            builder.Property(c => c.CreatedDate)
                .HasColumnName("created_date")
                .HasColumnType("timestamp")
                .HasDefaultValue(DateTime.Now)
                .IsRequired();

            builder.Property(c => c.UpdatedDate)
                .HasColumnName("updated_date")
                .HasColumnType("timestamp")
                .HasDefaultValue(DateTime.Now)
                .IsRequired();
        }
    }
}
