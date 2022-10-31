using IFC.Application.Contracts.Persistence.Repositries;
using IFC.Application.DTOs.SocialMediaProfile;

namespace IFC.Infrastructure.Persistence.Repositories;

public class SocialMediaProfileRepo : ISocialMediaProfileRepo
{
    private readonly IFCDbContext _dbContext;
    private readonly IMapper _mapper;

    public SocialMediaProfileRepo(IFCDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<SocialMediaProfileDTO>> GetSocialMediaProfileDetailsAsync()
    {
        return _mapper.Map<List<SocialMediaProfileDTO>>(await _dbContext.SocialMediaProfiles.ToListAsync());
    }
    public async Task<SocialMediaProfileDTO> GetSocialMediaProfileDetailsAsync(long? id)
    {
        var result = await _dbContext.SocialMediaProfiles
            .FirstOrDefaultAsync(m => m.Id == id);
        return _mapper.Map<SocialMediaProfileDTO>(result!);
    }
    public async Task CreateSocialMediaProfileDetailAsync(SocialMediaProfile socialMediaProfile)
    {
        _dbContext.Add(socialMediaProfile);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteSocialMediaProfileDetailAsync(long? id)
    {
        var socialMediaProfile = await _dbContext.SocialMediaProfiles.FindAsync(id);
        if (socialMediaProfile != null)
        {
            _dbContext.SocialMediaProfiles.Remove(socialMediaProfile);
        }
        await _dbContext.SaveChangesAsync();
    }
}
