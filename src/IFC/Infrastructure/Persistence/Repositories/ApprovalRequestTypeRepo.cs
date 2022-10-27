using IFC.Application.Contracts.Persistence.Repositries;

namespace IFC.Infrastructure.Persistence.Repositories;

public class ApprovalRequestTypeRequestTypeRepo : IApprovalRequestTypeRequestTypeRepo
{
    private readonly IFCDbContext _dbContext;
    public ApprovalRequestTypeRequestTypeRepo(IFCDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ApprovalRequestType>> GetApprovalRequestTypesAsync()
    {
        return await _dbContext.ApprovalRequestTypes.ToListAsync();
    }
    public async Task<ApprovalRequestType?> GetApprovalRequestTypesAsync(long? id)
    {
        return await _dbContext.ApprovalRequestTypes
            .FirstOrDefaultAsync(m => m.Id == id);
    }
    public async Task CreateApprovalRequestTypeAsync(ApprovalRequestType approvalRequestType)
    {
        _dbContext.Add(approvalRequestType);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteApprovalRequestTypeAsync(long? id)
    {
        var approvalRequestType = await _dbContext.ApprovalRequestTypes.FindAsync(id);
        if (approvalRequestType != null)
        {
            _dbContext.ApprovalRequestTypes.Remove(approvalRequestType);
        }

        await _dbContext.SaveChangesAsync();
    }
}