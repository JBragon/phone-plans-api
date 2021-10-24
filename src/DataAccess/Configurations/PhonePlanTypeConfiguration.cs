using JBragon.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JBragon.DataAccess.Configurations
{
    public class PhonePlanTypeConfiguration : IEntityTypeConfiguration<PhonePlanType>
    {
        public void Configure(EntityTypeBuilder<PhonePlanType> builder)
        {
            // Table & Column Mappings
            builder.ToTable("DDD");

            // Primary Key
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Description)
                .HasColumnName("Description")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.CreatedAt)
                .HasColumnName("CreatedAt")
                .IsRequired();

            builder.Property(t => t.UpdatedAt)
                .HasColumnName("UpdatedAt")
                .IsRequired();

            builder.HasMany(x => x.PhonePlans)
                .WithOne(y => y.PhonePlanType)
                .HasForeignKey(x => x.PhonePlanTypeId);

        }
    }
}
