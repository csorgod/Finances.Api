using Finances.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Finances.Infrastructure.Persistence.Configurations
{
    public class LoginJwtConfiguration : IEntityTypeConfiguration<LoginJwt>
    {
        public void Configure(EntityTypeBuilder<LoginJwt> builder)
        {
            builder
                .HasKey(lj => lj.Id);

            builder.Property(lj => lj.Id)
                .HasColumnName("id")
                .HasColumnType("varchar(36)")
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(lj => lj.UserId)
                .HasColumnName("user_id")
                .HasColumnType("varchar(36)")
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(lj => lj.Header)
                .HasColumnName("header")
                .HasColumnType("varchar(1000)")
                .HasMaxLength(1000)
                .IsRequired();

            builder.Property(lj => lj.Payload)
                .HasColumnName("payload")
                .HasColumnType("varchar(1000)")
                .HasMaxLength(1000)
                .IsRequired();

            builder.Property(lj => lj.Signature)
                .HasColumnName("signature")
                .HasColumnType("varchar(1000)")
                .HasMaxLength(1000)
                .IsRequired();

            builder.Property(lj => lj.Status)
                .HasColumnName("status")
                .HasColumnType("int(1)")
                .HasMaxLength(1)
                .IsRequired();

            builder.Property(lj => lj.ExpireDate)
                .HasColumnName("expire_date")
                .HasColumnType("timestamp")
                .HasDefaultValue();

            builder.Property(lj => lj.CreatedDate)
                .HasColumnName("created_date")
                .HasColumnType("timestamp")
                .HasDefaultValue(DateTime.Now)
                .IsRequired();

            builder.Property(lj => lj.UpdatedDate)
                .HasColumnName("updated_date")
                .HasColumnType("timestamp")
                .HasDefaultValue(DateTime.Now)
                .IsRequired();
        }
    }
}
