namespace IFC.Infrastructure.Persistence.Configurations;

public class CoreHeadQuaterConfiguration : IEntityTypeConfiguration<CoreHeadQuarter>
{
    public void Configure(EntityTypeBuilder<CoreHeadQuarter> entity)
    {
        entity.ToTable("CoreHeadQuarter");

        entity.Property(e => e.DisplayName).HasMaxLength(255);
        entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
        entity.Property(e => e.Name).HasMaxLength(255);

        entity.HasOne(d => d.SectorHeadQuarter)
            .WithMany(p => p.CoreHeadQuarters)
            .HasForeignKey(d => d.SectorHeadQuarterId)
            .HasConstraintName("FK_CoreHeadQuarter_SectorHeadQuarter")
            .OnDelete(DeleteBehavior.SetNull);
    }
}