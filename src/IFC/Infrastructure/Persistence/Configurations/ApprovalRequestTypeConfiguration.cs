namespace IFC.Infrastructure.Persistence.Configurations;

public class ApprovalRequestTypeConfiguration : IEntityTypeConfiguration<ApprovalRequestType>
{
    public void Configure(EntityTypeBuilder<ApprovalRequestType> entity)
    {
        entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

        entity.Property(e => e.RequestType).HasMaxLength(255);
    }
}