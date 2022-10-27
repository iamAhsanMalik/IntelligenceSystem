namespace IFC.Application.DTOs.ApprovalRequestType;

public class ApprovalRequestTypeDTO
{
    public long Id { get; set; }
    public string? RequestType { get; set; }
    public bool? IsDeleted { get; set; }
    public bool? IsActive { get; set; }
}
