namespace IFC.Infrastructure.Persistence.Repositories;

public class ApprovalRepo : IApprovalRepo
{
    private readonly IFCDbContext _dbContext;
    public ApprovalRepo(IFCDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Approval>> GetApprovalsAsync()
    {
        var iFCDbContext = _dbContext.Approvals.Include(a => a.ApprovalRequestType);
        return await iFCDbContext.ToListAsync();
    }
    public async Task<Approval?> GetApprovalsAsync(long? id)
    {
        return await _dbContext.Approvals.Include(a => a.ApprovalRequestType).FirstOrDefaultAsync(m => m.Id == id);
    }
    public async Task CreateApprovalsAsync(Approval approval)
    {
        _dbContext.Add(approval);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteApprovalsAsync(long? id)
    {
        var approval = await _dbContext.Approvals.FindAsync(id);
        if (approval != null)
        {
            _dbContext.Approvals.Remove(approval);
        }
        await _dbContext.SaveChangesAsync();
    }
}