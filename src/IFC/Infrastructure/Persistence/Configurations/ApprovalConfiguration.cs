namespace IFC.Infrastructure.Persistence.Configurations;

public class ApprovalConfiguration : IEntityTypeConfiguration<Approval>
{
    public void Configure(EntityTypeBuilder<Approval> entity)
    {
        entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
        entity.Property(e => e.ApprovalStatus).HasDefaultValueSql("((0))");

        entity.HasOne(d => d.ApprovalRequestType)
            .WithMany(p => p.Approvals)
            .HasForeignKey(d => d.ApprovalRequestTypeId)
            .HasConstraintName("FK_Approvals_ApprovalRequestTypes")
            .OnDelete(DeleteBehavior.NoAction);
    }
}
