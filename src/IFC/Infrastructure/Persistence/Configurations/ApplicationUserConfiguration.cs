using IFC.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IFC.Infrastructure.Persistence.Configurations;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(a => a.FirstName).HasMaxLength(125);
        builder.Property(a => a.LastName).HasMaxLength(125);
        builder.Property(a => a.CNIC).HasMaxLength(15).IsRequired();
        builder.Property(a => a.IsActive).HasDefaultValue(false).IsRequired();
    }
}
