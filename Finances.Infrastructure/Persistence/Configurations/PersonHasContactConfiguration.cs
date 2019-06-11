using Finances.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Infrastructure.Persistence.Configurations
{
    public class PersonHasContactConfiguration : IEntityTypeConfiguration<PersonHasContact>
    {
        public void Configure(EntityTypeBuilder<PersonHasContact> builder)
        {
            builder
               .HasKey(phc => phc.Id);

            builder.Property(phc => phc.Id)
                .HasColumnName("id")
                .HasColumnType("varchar(36)")
                .HasMaxLength(36)
                .IsRequired();
            
            builder.Property(phc => phc.PersonId)
                .HasColumnName("person_id")
                .HasColumnType("varchar(36)")
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(phc => phc.ContactId)
                .HasColumnName("contact_id")
                .HasColumnType("varchar(36)")
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(phc => phc.CreatedDate)
                .HasColumnName("created_date")
                .HasColumnType("timestamp")
                .HasDefaultValue(DateTime.Now)
                .IsRequired();

            builder.Property(phc => phc.UpdatedDate)
                .HasColumnName("updated_date")
                .HasColumnType("timestamp")
                .HasDefaultValue(DateTime.Now)
                .IsRequired();
        }
    }
}
