namespace IFC.Infrastructure.Persistence.Configurations;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> entity)
    {
        entity.Property(a => a.FirstName).HasMaxLength(125);
        entity.Property(a => a.LastName).HasMaxLength(125);
        entity.Property(a => a.CNIC).HasMaxLength(15).IsRequired();
        entity.Property(a => a.ProfileImage).HasMaxLength(100);
        entity.Property(a => a.IsDelete).HasDefaultValueSql("((0))");
        entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
    }
}