using IFC.Application.DTOs.SuspectProfile;

namespace IFC.Infrastructure.Persistence.Repositories;

public class SuspectProfileRepo : ISuspectProfileRepo
{
    private readonly IFCDbContext _dbContext;
    private readonly IMapper _mapper;

    public SuspectProfileRepo(IFCDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<SuspectProfileDTO>> GetSuspectProfilesAsync()
    {
        return _mapper.Map<List<SuspectProfileDTO>>(await _dbContext.SuspectProfiles.ToListAsync());
    }
    public async Task<SuspectProfileDTO> GetSuspectProfilesAsync(long? id)
    {
        var result = await _dbContext.SuspectProfiles
            .FirstOrDefaultAsync(m => m.Id == id);
        return _mapper.Map<SuspectProfileDTO>(result!);
    }
    public async Task CreateSuspectProfileAsync(SuspectProfile suspectProfile)
    {
        _dbContext.Add(suspectProfile);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteSuspectProfileAsync(long? id)
    {
        var suspectProfile = await _dbContext.SuspectProfiles.FindAsync(id);
        if (suspectProfile != null)
        {
            _dbContext.SuspectProfiles.Remove(suspectProfile);
        }
        await _dbContext.SaveChangesAsync();
    }
}
