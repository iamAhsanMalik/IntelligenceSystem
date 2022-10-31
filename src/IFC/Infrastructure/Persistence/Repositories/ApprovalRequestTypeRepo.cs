using IFC.Application.Contracts.Persistence.Repositries;
using IFC.Application.DTOs.ApprovalRequestType;

namespace IFC.Infrastructure.Persistence.Repositories;

public class ApprovalRequestTypeRepo : IApprovalRequestTypeRepo
{
    private readonly IFCDbContext _dbContext;
    private readonly IMapper _mapper;

    public ApprovalRequestTypeRepo(IFCDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<ApprovalRequestTypeDTO>> GetApprovalRequestTypesAsync()
    {
        return _mapper.Map<List<ApprovalRequestTypeDTO>>(await _dbContext.ApprovalRequestTypes.ToListAsync());
    }
    public async Task<ApprovalRequestTypeDTO> GetApprovalRequestTypesAsync(long? id)
    {
        var result = await _dbContext.ApprovalRequestTypes
            .FirstOrDefaultAsync(m => m.Id == id);
        return _mapper.Map<ApprovalRequestTypeDTO>(result!);
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