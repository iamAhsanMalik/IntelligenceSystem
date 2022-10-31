namespace IFC.Domain.Entities;

public class ApprovalRequestType
{
    public ApprovalRequestType()
    {
        Approvals = new HashSet<Approval>();
    }

    public long Id { get; set; }
    public string? RequestType { get; set; }
    public bool? IsDeleted { get; set; }
    public bool? IsActive { get; set; }

    public virtual ICollection<Approval> Approvals { get; set; }
}