using IFC.Application.DTOs.Approval;

namespace IFC.Application.Contracts.Persistence.Repositries;

public interface IApprovalRepo
{
    Task CreateApprovalAsync(Approval approval);
    Task DeleteApprovalAsync(long? id);
    Task<List<ApprovalDTO>> GetApprovalsAsync();
    Task<ApprovalDTO> GetApprovalsAsync(long? id);
}