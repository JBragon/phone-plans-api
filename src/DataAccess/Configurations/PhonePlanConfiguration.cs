using JBragon.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JBragon.DataAccess.Configurations
{
    public class PhonePlanConfiguration : IEntityTypeConfiguration<PhonePlan>
    {
        public void Configure(EntityTypeBuilder<PhonePlan> builder)
        {
            // Table & Column Mappings
            builder.ToTable("PhonePlan");

            // Primary Key
            builder.HasKey(t => t.Id);

            builder.Property(t => t.DDDId)
                .HasColumnName("DDDId")
                .IsRequired();

            builder.Property(t => t.TelephoneOperatorId)
                .HasColumnName("TelephoneOperatorId")
                .IsRequired();
            
            builder.Property(t => t.PhonePlanTypeId)
                .HasColumnName("PhonePlanTypeId")
                .IsRequired();

            builder.Property(t => t.Minutes)
                .HasColumnName("Minutes")
                .IsRequired();

            builder.Property(t => t.InternetFranchise)
                .HasColumnName("InternetFranchise")
                .IsRequired();

            builder.Property(t => t.PlanPrice)
                .HasColumnName("PlanPrice")
                .IsRequired();

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


            builder.HasIndex(p => new { p.DDDId, p.TelephoneOperatorId, p.Name })
                .IsUnique(true);

        }
    }
}
