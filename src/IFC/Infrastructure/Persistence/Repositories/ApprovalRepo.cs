using IFC.Application.Contracts.Persistence.Repositries;
using IFC.Application.DTOs.Approval;

namespace IFC.Infrastructure.Persistence.Repositories;

public class ApprovalRepo : IApprovalRepo
{
    private readonly IFCDbContext _dbContext;
    private readonly IMapper _mapper;

    public ApprovalRepo(IFCDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<ApprovalDTO>> GetApprovalsAsync()
    {
        var iFCDbContext = _dbContext.Approvals.Include(a => a.ApprovalRequestType);
        return _mapper.Map<List<ApprovalDTO>>(await iFCDbContext.ToListAsync());
    }
    public async Task<ApprovalDTO> GetApprovalsAsync(long? id)
    {
        var result = await _dbContext.Approvals.Include(a => a.ApprovalRequestType).FirstOrDefaultAsync(m => m.Id == id);
        return _mapper.Map<ApprovalDTO>(result!);
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