using Finances.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Finances.Infrastructure.Persistence.Configurations
{
    public class IncomingConfiguration : IEntityTypeConfiguration<Incoming>
    {
        public void Configure(EntityTypeBuilder<Incoming> builder)
        {
            builder
                .HasKey(i => i.Id);

            builder.Property(i => i.Id)
                .HasColumnName("id")
                .HasColumnType("varchar(36)")
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(i => i.PersonId)
                .HasColumnName("person_id")
                .HasColumnType("varchar(36)")
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(i => i.IncomeType)
                .HasColumnName("income_type")
                .HasColumnType("int(1)")
                .HasMaxLength(1)
                .IsRequired();

            builder.Property(i => i.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(30)")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(i => i.Description)
                .HasColumnName("description")
                .HasColumnType("varchar(1000)")
                .HasMaxLength(1000);

            builder.Property(i => i.Value)
                .HasColumnName("value")
                .HasColumnType("double")
                .IsRequired();

            builder.Property(i => i.Status)
                .HasColumnName("status")
                .HasColumnType("int(1)")
                .HasMaxLength(1)
                .IsRequired();

            builder.Property(i => i.ReceiveAt)
                .HasColumnName("receive_at")
                .HasColumnType("timestamp")
                .HasDefaultValue(null);

            builder.Property(i => i.Recurrent)
                .HasColumnName("recurrent")
                .HasColumnType("boolean")
                .HasDefaultValue(null);

            builder.Property(i => i.CreatedDate)
                .HasColumnName("created_date")
                .HasColumnType("timestamp")
                .HasDefaultValue(DateTime.Now)
                .IsRequired();

            builder.Property(i => i.UpdatedDate)
                .HasColumnName("updated_date")
                .HasColumnType("timestamp")
                .HasDefaultValue(DateTime.Now)
                .IsRequired();
        }
    }
}
