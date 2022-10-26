namespace IFC.Infrastructure.Persistence.Repositories;

public interface IApprovalRepo
{
    Task CreateApprovalsAsync(Approval approval);
    Task DeleteApprovalsAsync(long? id);
    Task<List<Approval>> GetApprovalsAsync();
    Task<Approval?> GetApprovalsAsync(long? id);
}