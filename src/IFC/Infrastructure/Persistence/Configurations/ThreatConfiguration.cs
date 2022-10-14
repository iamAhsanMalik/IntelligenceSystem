namespace IFC.Infrastructure.Persistence.Configurations;

public class ThreatConfigurations : IEntityTypeConfiguration<Threat>
{
    public void Configure(EntityTypeBuilder<Threat> entity)
    {
        entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

        entity.Property(e => e.ThreatLevel);

        entity.HasOne(d => d.Incident)
            .WithMany(p => p.Threats)
            .HasForeignKey(d => d.IncidentId)
            .HasConstraintName("FK_Threats_Incidents")
            .OnDelete(DeleteBehavior.SetNull);

        entity.HasOne(d => d.Location)
            .WithMany(p => p.Threats)
            .HasForeignKey(d => d.LocationId)
            .HasConstraintName("FK_Threats_Location")
            .OnDelete(DeleteBehavior.SetNull);

        entity.HasOne(d => d.Organization)
            .WithMany(p => p.Threats)
            .HasForeignKey(d => d.OrganizationId)
            .HasConstraintName("FK_Threats_Organizations")
            .OnDelete(DeleteBehavior.SetNull);

        entity.HasOne(d => d.SuspectsProfile)
            .WithMany(p => p.Threats)
            .HasForeignKey(d => d.SuspectsProfileId)
            .HasConstraintName("FK_Threats_SuspectProfiles")
            .OnDelete(DeleteBehavior.SetNull);

        entity.HasOne(d => d.Wing)
            .WithMany(p => p.Threats)
            .HasForeignKey(d => d.WingId)
            .HasConstraintName("FK_Threats_Wing")
            .OnDelete(DeleteBehavior.SetNull);
    }
}