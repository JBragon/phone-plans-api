using JBragon.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JBragon.DataAccess.Configurations
{
    public class DDDConfiguration : IEntityTypeConfiguration<DDD>
    {
        public void Configure(EntityTypeBuilder<DDD> builder)
        {
            // Table & Column Mappings
            builder.ToTable("DDD");

            // Primary Key
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Region)
                .HasColumnName("Region")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.State)
                .HasColumnName("State")
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(t => t.DDDCode)
                .HasColumnName("DDDCode")
                .IsRequired();

            builder.Property(t => t.CreatedAt)
                .HasColumnName("CreatedAt")
                .IsRequired();

            builder.Property(t => t.UpdatedAt)
                .HasColumnName("UpdatedAt")
                .IsRequired();

            builder.HasMany(x => x.PhonePlans)
                .WithOne(y => y.DDD)
                .HasForeignKey(x => x.DDDId);

            builder.HasIndex(p => new { p.DDDCode })
                .IsUnique(true);
        }
    }
}
