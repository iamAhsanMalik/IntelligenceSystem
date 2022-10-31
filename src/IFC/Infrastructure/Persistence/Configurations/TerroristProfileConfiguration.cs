namespace IFC.Infrastructure.Persistence.Configurations;

public class TerroristProfileConfigurations : IEntityTypeConfiguration<TerroristProfile>
{
    public void Configure(EntityTypeBuilder<TerroristProfile> entity)
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


        entity.Property(e => e.IsFounder).HasDefaultValueSql("((0))");

        entity.Property(e => e.LastName).HasMaxLength(150);

        entity.Property(e => e.NameAlias).HasMaxLength(255);

        entity.Property(e => e.Passport).HasMaxLength(50);

        entity.Property(e => e.Sect).HasMaxLength(255);

        entity.Property(e => e.TribeOrCast).HasMaxLength(255);

        entity.HasOne(d => d.Address)
            .WithMany(p => p.TerroristProfiles)
            .HasForeignKey(d => d.AddressId)
            .HasConstraintName("FK_TerroristProfiles_Address")
            .OnDelete(DeleteBehavior.SetNull);

        entity.HasOne(d => d.Organization)
            .WithMany(p => p.TerroristProfiles)
            .HasForeignKey(d => d.OrganizationId)
            .HasConstraintName("FK_TerroristProfiles_Organizations")
            .OnDelete(DeleteBehavior.SetNull);

        entity.HasOne(d => d.TerroristFacilitatorsDetails)
            .WithMany(p => p.TerroristProfiles)
            .HasForeignKey(d => d.TerroristFacilitatorsDetailsId)
            .HasConstraintName("FK_TerroristProfiles_TerroristFacilitatorsDetails")
            .OnDelete(DeleteBehavior.SetNull);

        entity.HasOne(d => d.TerroristFamilyDetails)
            .WithMany(p => p.TerroristProfiles)
            .HasForeignKey(d => d.TerroristFamilyDetailsId)
            .HasConstraintName("FK_TerroristProfiles_TerroristFamilyDetails")
            .OnDelete(DeleteBehavior.SetNull);

        entity.HasOne(d => d.TerroristInvolvement)
            .WithMany(p => p.TerroristProfiles)
            .HasForeignKey(d => d.TerroristInvolvementId)
            .HasConstraintName("FK_TerroristProfiles_TerroristInvolvements")
            .OnDelete(DeleteBehavior.SetNull);
    }
}