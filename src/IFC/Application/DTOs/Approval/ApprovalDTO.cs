namespace IFC.Application.DTOs.Approval;

public class ApprovalDTO
{
    public long Id { get; set; }

    public DateTime? InitiatedOn { get; set; }
    public bool? ApprovalStatus { get; set; }
    public bool? IsDeleted { get; set; }
    public bool? IsActive { get; set; }

    public virtual string? ApprovalRequestType { get; set; }
}
