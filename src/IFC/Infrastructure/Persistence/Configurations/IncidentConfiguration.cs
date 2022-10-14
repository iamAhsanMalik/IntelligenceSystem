namespace IFC.Infrastructure.Persistence.Configurations;

public class IncidentConfiguration : IEntityTypeConfiguration<Incident>
{
    public void Configure(EntityTypeBuilder<Incident> entity)
    {
        entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

        entity.HasOne(d => d.Location)
            .WithMany(p => p.Incidents)
            .HasForeignKey(d => d.LocationId)
            .HasConstraintName("FK_Incidents_Location")
            .OnDelete(DeleteBehavior.SetNull);

        entity.HasOne(d => d.Organization)
            .WithMany(p => p.Incidents)
            .HasForeignKey(d => d.OrganizationId)
            .HasConstraintName("FK_Incidents_Organizations")
            .OnDelete(DeleteBehavior.SetNull);

        entity.HasOne(d => d.SuspectsProfile)
            .WithMany(p => p.Incidents)
            .HasForeignKey(d => d.SuspectsProfileId)
            .HasConstraintName("FK_Incidents_SuspectProfiles")
            .OnDelete(DeleteBehavior.SetNull);

        entity.HasOne(d => d.Wing)
            .WithMany(p => p.Incidents)
            .HasForeignKey(d => d.WingId)
            .HasConstraintName("FK_Incidents_Wing")
            .OnDelete(DeleteBehavior.SetNull);
    }
}