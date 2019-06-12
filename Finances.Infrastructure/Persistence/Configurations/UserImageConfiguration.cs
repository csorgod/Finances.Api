using Finances.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Finances.Infrastructure.Persistence.Configurations
{
    public class UserImageConfiguration : IEntityTypeConfiguration<UserImage>
    {
        public void Configure(EntityTypeBuilder<UserImage> builder)
        {
            builder
                .HasKey(ui => ui.Id);

            builder.Property(ui => ui.Id)
                .HasColumnName("id")
                .HasColumnType("varchar(36)")
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(ui => ui.UserId)
                .HasColumnName("user_id")
                .HasColumnType("varchar(36)")
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(ui => ui.Path)
                .HasColumnName("path")
                .HasColumnType("varchar(500)")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(ui => ui.CreatedDate)
                .HasColumnName("created_date")
                .HasColumnType("timestamp")
                .HasDefaultValue(DateTime.Now)
                .IsRequired();

            builder.Property(ui => ui.UpdatedDate)
                .HasColumnName("updated_date")
                .HasColumnType("timestamp")
                .HasDefaultValue(DateTime.Now)
                .IsRequired();
        }
    }
}
