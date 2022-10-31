namespace IFC.Infrastructure.Persistence.Configurations;

public class FunderConfiguration : IEntityTypeConfiguration<Funder>
{
    public void Configure(EntityTypeBuilder<Funder> entity)
    {
        entity.Property(e => e.FundingSource).HasMaxLength(255);

        entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

        entity.Property(e => e.Name).HasMaxLength(255);
    }
}