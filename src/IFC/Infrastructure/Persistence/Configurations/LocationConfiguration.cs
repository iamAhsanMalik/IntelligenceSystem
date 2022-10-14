namespace IFC.Infrastructure.Persistence.Configurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> entity)
    {
        entity.ToTable("Location");

        entity.Property(e => e.Latitude).HasColumnType("decimal(8, 6)");

        entity.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");

        entity.Property(e => e.Name).HasMaxLength(255);
        entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

    }
}