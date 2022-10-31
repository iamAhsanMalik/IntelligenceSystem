namespace IFC.Infrastructure.Persistence.Configurations;

public class OperationalBasesConfiguration : IEntityTypeConfiguration<OperationalBase>
{
    public void Configure(EntityTypeBuilder<OperationalBase> entity)
    {
        entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

        entity.Property(e => e.Name).HasMaxLength(255);
        entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
    }
}