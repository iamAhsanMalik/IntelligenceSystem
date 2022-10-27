namespace IFC.Infrastructure.Persistence.Repositories;

public interface IApprovalRequestTypeRequestTypeRepo
{
    Task CreateApprovalRequestTypeAsync(ApprovalRequestType approvalRequestType);
    Task DeleteApprovalRequestTypeAsync(long? id);
    Task<List<ApprovalRequestType>> GetApprovalRequestTypesAsync();
    Task<ApprovalRequestType?> GetApprovalRequestTypesAsync(long? id);
}