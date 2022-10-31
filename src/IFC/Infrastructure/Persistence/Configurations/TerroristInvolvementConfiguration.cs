namespace IFC.Infrastructure.Persistence.Configurations;

public class TerroristInvolvementConfigurations : IEntityTypeConfiguration<TerroristInvolvement>
{
    public void Configure(EntityTypeBuilder<TerroristInvolvement> entity)
    {
        entity.Property(e => e.Involvement).HasMaxLength(255);

        entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

    }
}