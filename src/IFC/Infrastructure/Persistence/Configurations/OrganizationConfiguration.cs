namespace IFC.Infrastructure.Persistence.Configurations;

public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
{
    public void Configure(EntityTypeBuilder<Organization> entity)
    {
        entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

        entity.Property(e => e.Name).HasMaxLength(255);

        entity.HasOne(d => d.Affiliate)
            .WithMany(p => p.Organizations)
            .HasForeignKey(d => d.AffiliateId)
            .HasConstraintName("FK_Organizations_Affiliates")
            .OnDelete(DeleteBehavior.SetNull);

        entity.HasOne(d => d.Involvement)
            .WithMany(p => p.Organizations)
            .HasForeignKey(d => d.InvolvementId)
            .HasConstraintName("FK_Organizations_Involvements")
            .OnDelete(DeleteBehavior.SetNull);

        entity.HasOne(d => d.OperationalBase)
            .WithMany(p => p.Organizations)
            .HasForeignKey(d => d.OperationalBaseId)
            .HasConstraintName("FK_Organizations_OperationalBases")
            .OnDelete(DeleteBehavior.SetNull);

        entity.HasOne(d => d.SocialMediaProfile)
            .WithMany(p => p.Organizations)
            .HasForeignKey(d => d.SocialMediaProfileId)
            .HasConstraintName("FK_Organizations_SocialMediaProfiles")
            .OnDelete(DeleteBehavior.SetNull);
    }
}