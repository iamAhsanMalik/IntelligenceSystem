namespace IFC.Infrastructure.Persistence.Configurations;

public class SocialMediaProfileConfiguration : IEntityTypeConfiguration<SocialMediaProfile>
{
    public void Configure(EntityTypeBuilder<SocialMediaProfile> entity)
    {
        entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

        entity.Property(e => e.Name)
            .HasMaxLength(255)
            .HasColumnName("SocialMediaProfile");
    }
}