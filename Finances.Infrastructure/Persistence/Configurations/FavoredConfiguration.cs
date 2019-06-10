using Finances.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finances.Infrastructure.Persistence.Configurations
{
    public class FavoredConfiguration : IEntityTypeConfiguration<Favored>
    {
        public void Configure(EntityTypeBuilder<Favored> builder)
        {
            builder
                .HasKey(f => f.Id);
            
            builder.Property(f => f.Id)
                .HasColumnName("id")
                .HasColumnType("varchar(36)")
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(f => f.BelongsToUserId)
                .HasColumnName("belongs_to_user_id")
                .HasColumnType("varchar(36)")
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(f => f.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(f => f.TaxNumber)
                .HasColumnName("tax_number")
                .HasColumnType("varchar(14)")
                .HasMaxLength(14)
                .IsRequired();

            builder.Property(f => f.Status)
                .HasColumnName("status")
                .HasColumnType("int(1)")
                .HasMaxLength(1)
                .IsRequired();

            builder.Property(f => f.CreatedDate)
                .HasColumnName("created_date")
                .HasColumnType("timestamp")
                .IsRequired();

            builder.Property(f => f.UpdatedDate)
                .HasColumnName("updated_date")
                .HasColumnType("timestamp")
                .IsRequired();

        }
    }
}
