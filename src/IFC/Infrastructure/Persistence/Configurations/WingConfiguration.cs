namespace IFC.Infrastructure.Persistence.Configurations;

public class WingConfigurations : IEntityTypeConfiguration<Wing>
{
    public void Configure(EntityTypeBuilder<Wing> entity)
    {
        entity.ToTable("Wing");

        entity.Property(e => e.DisplayName).HasMaxLength(255);

        entity.Property(e => e.IsSacaapplied).HasColumnName("IsSACAApplied");

        entity.Property(e => e.Name).HasMaxLength(255);
        entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
        entity.Property(e => e.Sacatype).HasColumnName("SACAType");

        entity.HasOne(d => d.CoreHeadQuarter)
            .WithMany(p => p.Wings)
            .HasForeignKey(d => d.CoreHeadQuarterId)
            .HasConstraintName("FK_Wing_CoreHeadQuarter")
            .OnDelete(DeleteBehavior.SetNull);
    }
}