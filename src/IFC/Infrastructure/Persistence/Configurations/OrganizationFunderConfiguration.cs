namespace IFC.Infrastructure.Persistence.Configurations;

public class OrganizationFunderConfiguration : IEntityTypeConfiguration<OrganizationFunder>
{
    public void Configure(EntityTypeBuilder<OrganizationFunder> entity)
    {
        entity.HasOne(d => d.Funder)
                    .WithMany(p => p.OrganizationFunders)
                    .HasForeignKey(d => d.FunderId)
                    .HasConstraintName("FK_OrganizationFunders_Funders")
                    .OnDelete(DeleteBehavior.SetNull);

        entity.HasOne(d => d.Organization)
            .WithMany(p => p.OrganizationFunders)
            .HasForeignKey(d => d.OrganizationId)
            .HasConstraintName("FK_OrganizationFunders_Organizations")
            .OnDelete(DeleteBehavior.SetNull);
    }
}