namespace IFC.Infrastructure.Persistence.Configurations;

public class SuspectFamilyDetailConfiguration : IEntityTypeConfiguration<SuspectFamilyDetail>
{
    public void Configure(EntityTypeBuilder<SuspectFamilyDetail> entity)
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

        entity.HasOne(d => d.RelationType)
            .WithMany(p => p.SuspectFamilyDetails)
            .HasForeignKey(d => d.RelationTypeId)
            .HasConstraintName("FK_SuspectFamilyDetails_RelationTypes")
            .OnDelete(DeleteBehavior.SetNull);
    }
}