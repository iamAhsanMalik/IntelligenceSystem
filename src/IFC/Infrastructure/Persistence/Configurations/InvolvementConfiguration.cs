namespace IFC.Infrastructure.Persistence.Configurations;

public class InvolvementConfiguration : IEntityTypeConfiguration<Involvement>
{
    public void Configure(EntityTypeBuilder<Involvement> entity)
    {
        entity.Property(e => e.Name).HasMaxLength(255);

        entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

    }
}