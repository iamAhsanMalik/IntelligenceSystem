namespace IFC.Infrastructure.Persistence.Configurations;

public class DistrictConfiguration : IEntityTypeConfiguration<District>
{
    public void Configure(EntityTypeBuilder<District> entity)
    {
        entity.ToTable("District");

        entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

        entity.Property(e => e.Name).HasMaxLength(255);
    }
}