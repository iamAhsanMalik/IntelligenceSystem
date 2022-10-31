namespace IFC.Domain.Entities;

public class Approval
{
    public long Id { get; set; }
    public long? ApprovalRequestTypeId { get; set; }
    public DateTime? InitiatedOn { get; set; }
    public bool? ApprovalStatus { get; set; }
    public bool? IsDeleted { get; set; }
    public bool? IsActive { get; set; }

    public virtual ApprovalRequestType? ApprovalRequestType { get; set; } = new ApprovalRequestType();
}