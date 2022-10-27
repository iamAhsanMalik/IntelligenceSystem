namespace IFC.Application.Contracts.Persistence.Repositries;

public interface IApprovalRequestTypeRepo
{
    Task CreateApprovalRequestTypeAsync(ApprovalRequestType approvalRequestType);
    Task DeleteApprovalRequestTypeAsync(long? id);
    Task<List<ApprovalRequestType>> GetApprovalRequestTypesAsync();
    Task<ApprovalRequestType?> GetApprovalRequestTypesAsync(long? id);
}