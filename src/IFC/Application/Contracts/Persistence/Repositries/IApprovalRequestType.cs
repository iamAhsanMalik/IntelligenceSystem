using IFC.Application.DTOs.ApprovalRequestType;

namespace IFC.Application.Contracts.Persistence.Repositries;

public interface IApprovalRequestTypeRepo
{
    Task CreateApprovalRequestTypeAsync(ApprovalRequestType approvalRequestType);
    Task DeleteApprovalRequestTypeAsync(long? id);
    Task<List<ApprovalRequestTypeDTO>> GetApprovalRequestTypesAsync();
    Task<ApprovalRequestTypeDTO> GetApprovalRequestTypesAsync(long? id);
}