namespace IFC.Infrastructure.Persistence.Configurations;

public class RelationTypeConfigurations : IEntityTypeConfiguration<RelationType>
{
    public void Configure(EntityTypeBuilder<RelationType> entity)
    {
        entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

        entity.Property(e => e.Name)
            .HasMaxLength(255)
            .HasColumnName("Name");
    }
}