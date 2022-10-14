namespace IFC.Infrastructure.Persistence.Configurations;

public class SectorHeadQuarterConfiguration : IEntityTypeConfiguration<SectorHeadQuarter>
{
    public void Configure(EntityTypeBuilder<SectorHeadQuarter> entity)
    {
        entity.ToTable("SectorHeadQuarter");

        entity.Property(e => e.Description);

        entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

        entity.Property(e => e.Name).HasMaxLength(30);
        entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

    }
}