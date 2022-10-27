namespace IFC.Infrastructure.Persistence.Configurations;

public class SuspectProfileConfiguration : IEntityTypeConfiguration<SuspectProfile>
{
    public void Configure(EntityTypeBuilder<SuspectProfile> entity)
    {
        entity.Property(e => e.CNIC)
                    .HasMaxLength(15)
                    .HasColumnName("CNIC");

        entity.Property(e => e.DateOfBirth).HasColumnType("date");

        entity.Property(e => e.FatherName).HasMaxLength(255);

        entity.Property(e => e.FirstName).HasMaxLength(150);

        entity.Property(e => e.GeneralRemarks);

        entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");


        entity.Property(e => e.LastName).HasMaxLength(150);

        entity.Property(e => e.Passport).HasMaxLength(50);

        entity.Property(e => e.Sect).HasMaxLength(255);

        entity.Property(e => e.TribeOrCast).HasMaxLength(255);

        entity.HasOne(d => d.Address)
            .WithMany(p => p.SuspectProfiles)
            .HasForeignKey(d => d.AddressId)
            .HasConstraintName("FK_SuspectProfiles_Address")
            .OnDelete(DeleteBehavior.SetNull);

        entity.HasOne(d => d.Organization)
            .WithMany(p => p.SuspectProfiles)
            .HasForeignKey(d => d.OrgnizationId)
            .HasConstraintName("FK_SuspectProfiles_Organizations")
            .OnDelete(DeleteBehavior.SetNull);

        entity.HasOne(d => d.SuspectFamilyDetails)
            .WithMany(p => p.SuspectProfiles)
            .HasForeignKey(d => d.SuspectFamilyDetailsId)
            .HasConstraintName("FK_SuspectProfiles_SuspectFamilyDetails")
            .OnDelete(DeleteBehavior.SetNull);
    }
}