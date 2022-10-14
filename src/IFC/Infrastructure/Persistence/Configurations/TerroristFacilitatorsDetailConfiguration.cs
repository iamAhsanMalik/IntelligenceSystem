namespace IFC.Infrastructure.Persistence.Configurations;

public class TerroristFacilitatorsDetailConfigurations : IEntityTypeConfiguration<TerroristFacilitatorsDetail>
{
    public void Configure(EntityTypeBuilder<TerroristFacilitatorsDetail> entity)
    {
        entity.Property(e => e.CNIC)
                     .HasMaxLength(15)
                     .HasColumnName("CNIC");

        entity.Property(e => e.DateOfBirth).HasColumnType("date");

        entity.Property(e => e.FirstName).HasMaxLength(150);

        entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");


        entity.Property(e => e.LastName).HasMaxLength(150);

        entity.Property(e => e.Passport).HasMaxLength(50);

        entity.Property(e => e.Sect).HasMaxLength(255);

        entity.Property(e => e.TribeOrCast).HasMaxLength(255);

        entity.HasOne(d => d.Address)
            .WithMany(p => p.TerroristFacilitatorsDetails)
            .HasForeignKey(d => d.AddressId)
            .HasConstraintName("FK_TerroristFacilitatorsDetails_Address")
            .OnDelete(DeleteBehavior.SetNull);

        entity.HasOne(d => d.RelationType)
            .WithMany(p => p.TerroristFacilitatorsDetails)
            .HasForeignKey(d => d.RelationTypeId)
            .HasConstraintName("FK_TerroristFacilitatorsDetails_RelationTypes")
            .OnDelete(DeleteBehavior.SetNull);
    }
}