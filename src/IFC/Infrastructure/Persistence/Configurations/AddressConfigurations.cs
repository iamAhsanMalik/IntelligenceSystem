namespace IFC.Infrastructure.Persistence.Configurations;

public class AddressConfigurations : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> entity)
    {
        entity.ToTable("Address");

        entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

        entity.Property(e => e.Streat).HasMaxLength(255);

        entity.HasOne(d => d.City)
            .WithMany(p => p.Addresses)
            .HasForeignKey(d => d.CityId)
            .HasConstraintName("FK_Address_City")
            .OnDelete(DeleteBehavior.SetNull);

        entity.HasOne(d => d.District)
            .WithMany(p => p.Addresses)
            .HasForeignKey(d => d.DistrictId)
            .HasConstraintName("FK_Address_District")
            .OnDelete(DeleteBehavior.SetNull);
    }
}