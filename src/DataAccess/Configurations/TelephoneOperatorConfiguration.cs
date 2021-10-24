using JBragon.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JBragon.DataAccess.Configurations
{
    public class TelephoneOperatorConfiguration : IEntityTypeConfiguration<TelephoneOperator>
    {
        public void Configure(EntityTypeBuilder<TelephoneOperator> builder)
        {
            // Table & Column Mappings
            builder.ToTable("TelephoneOperator");

            // Primary Key
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                .HasColumnName("Name")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.CreatedAt)
                .HasColumnName("CreatedAt")
                .IsRequired();

            builder.Property(t => t.UpdatedAt)
                .HasColumnName("UpdatedAt")
                .IsRequired();

            builder.HasMany(x => x.PhonePlans)
                .WithOne(y => y.TelephoneOperator)
                .HasForeignKey(x => x.TelephoneOperatorId);

            builder.HasIndex(p => new { p.Name })
                .IsUnique(true);
        }
    }
}
