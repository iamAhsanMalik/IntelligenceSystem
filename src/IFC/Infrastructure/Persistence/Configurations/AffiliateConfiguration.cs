namespace IFC.Infrastructure.Persistence.Configurations;

public class AffiliateConfiguration : IEntityTypeConfiguration<Affiliate>
{
    public void Configure(EntityTypeBuilder<Affiliate> entity)
    {
        entity.Property(e => e.ForiegnAffiliate).HasMaxLength(255);

        entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

        entity.Property(e => e.LocalAffiliate).HasMaxLength(255);
        entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
    }
}