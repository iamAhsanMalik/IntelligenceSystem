using IFC.Application.Contracts.Persistence.Repositries;
using IFC.Application.DTOs.SuspectFamilyDetail;

namespace IFC.Infrastructure.Persistence.Repositories;

public class SuspectFamilyDetailRepo : ISuspectFamilyDetailRepo
{
    private readonly IFCDbContext _dbContext;
    private readonly IMapper _mapper;

    public SuspectFamilyDetailRepo(IFCDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<SuspectFamilyDetailDTO>> GetSuspectFamilyDetailsAsync()
    {
        return _mapper.Map<List<SuspectFamilyDetailDTO>>(await _dbContext.SuspectFamilyDetails.ToListAsync());
    }
    public async Task<SuspectFamilyDetailDTO> GetSuspectFamilyDetailsAsync(long? id)
    {
        var result = await _dbContext.SuspectFamilyDetails
            .FirstOrDefaultAsync(m => m.Id == id);
        return _mapper.Map<SuspectFamilyDetailDTO>(result!);
    }
    public async Task CreateSuspectFamilyDetailAsync(SuspectFamilyDetail suspectFamilyDetail)
    {
        _dbContext.Add(suspectFamilyDetail);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteSuspectFamilyDetailAsync(long? id)
    {
        var suspectFamilyDetail = await _dbContext.SuspectFamilyDetails.FindAsync(id);
        if (suspectFamilyDetail != null)
        {
            _dbContext.SuspectFamilyDetails.Remove(suspectFamilyDetail);
        }
        await _dbContext.SaveChangesAsync();
    }
}
