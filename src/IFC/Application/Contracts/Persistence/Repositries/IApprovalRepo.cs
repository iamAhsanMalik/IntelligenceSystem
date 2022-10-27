namespace IFC.Application.Contracts.Persistence.Repositries;

public interface IApprovalRepo
{
    Task CreateApprovalsAsync(Approval approval);
    Task DeleteApprovalsAsync(long? id);
    Task<List<Approval>> GetApprovalsAsync();
    Task<Approval?> GetApprovalsAsync(long? id);
}