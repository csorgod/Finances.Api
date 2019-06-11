using Finances.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Infrastructure.Persistence.Configurations
{
    public class UserHasPersonConfiguration : IEntityTypeConfiguration<UserHasPerson>
    {
        public void Configure(EntityTypeBuilder<UserHasPerson> builder)
        {
            builder
               .HasKey(uhp => uhp.Id);

            builder.Property(uhp => uhp.Id)
                .HasColumnName("id")
                .HasColumnType("varchar(36)")
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(uhp => uhp.UserId)
                .HasColumnName("user_id")
                .HasColumnType("varchar(36)")
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(uhp => uhp.PersonId)
                .HasColumnName("person_id")
                .HasColumnType("varchar(36)")
                .HasMaxLength(36)
                .IsRequired();
            
            builder.Property(uhp => uhp.CreatedDate)
                .HasColumnName("created_date")
                .HasColumnType("timestamp")
                .HasDefaultValue(DateTime.Now)
                .IsRequired();

            builder.Property(uhp => uhp.UpdatedDate)
                .HasColumnName("updated_date")
                .HasColumnType("timestamp")
                .HasDefaultValue(DateTime.Now)
                .IsRequired();
        }
    }
}
