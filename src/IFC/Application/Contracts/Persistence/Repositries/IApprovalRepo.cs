using IFC.Application.DTOs.Approval;

namespace IFC.Application.Contracts.Persistence.Repositries;

public interface IApprovalRepo
{
    Task CreateApprovalsAsync(Approval approval);
    Task DeleteApprovalsAsync(long? id);
    Task<List<ApprovalDTO>> GetApprovalsAsync();
    Task<ApprovalDTO> GetApprovalsAsync(long? id);
}