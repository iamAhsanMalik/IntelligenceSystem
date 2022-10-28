using IFC.Application.Contracts.Persistence.Repositries;
using IFC.Application.DTOs.TerroristProfile;

namespace IFC.Infrastructure.Persistence.Repositories;

public class TerroristProfileRepo : ITerroristProfileRepo
{
    private readonly IFCDbContext _dbContext;
    private readonly IMapper _mapper;

    public TerroristProfileRepo(IFCDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<TerroristProfileDTO>> GetTerroristProfilesAsync()
    {
        return _mapper.Map<List<TerroristProfileDTO>>(await _dbContext.TerroristProfiles.Include(t => t.Address).Include(t => t.Organization).Include(t => t.TerroristFacilitatorsDetails).Include(t => t.TerroristFamilyDetails).Include(t => t.TerroristInvolvement).ToListAsync());


    }
    public async Task<TerroristProfileDTO> GetTerroristProfilesAsync(long? id)
    {
        var result = await _dbContext.TerroristProfiles
               .Include(t => t.Address)
               .Include(t => t.Organization)
               .Include(t => t.TerroristFacilitatorsDetails)
               .Include(t => t.TerroristFamilyDetails)
               .Include(t => t.TerroristInvolvement)
               .FirstOrDefaultAsync(m => m.Id == id);
        return _mapper.Map<TerroristProfileDTO>(result!);

    }
    public async Task CreateTerroristProfileAsync(TerroristProfile TerroristProfiles)
    {
        _dbContext.Add(TerroristProfiles);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteTerroristProfileAsync(long? id)
    {
        var TerroristProfile = await _dbContext.TerroristProfiles.FindAsync(id);
        if (TerroristProfile != null)
        {
            _dbContext.TerroristProfiles.Remove(TerroristProfile);
        }
        await _dbContext.SaveChangesAsync();
    }
}
