namespace IFC.Infrastructure.Persistence.Repositories;

public class SocialMediaProfileRepo : ISocialMediaProfileRepo
{
    private readonly IFCDbContext _dbContext;
    public SocialMediaProfileRepo(IFCDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<SocialMediaProfile>> GetSocialMediaProfileDetailReposAsync()
    {
        var iFCDbContext = await _dbContext.SocialMediaProfiles.ToListAsync();

        return iFCDbContext;
    }
    public async Task<SocialMediaProfile?> GetSocialMediaProfileDetailReposAsync(long? id)
    {
        return await _dbContext.SocialMediaProfiles
            .FirstOrDefaultAsync(m => m.Id == id);

    }
    public async Task CreateSocialMediaProfileDetailAsync(SocialMediaProfile socialMediaProfile)
    {
        _dbContext.Add(socialMediaProfile);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteSocialMediaProfileDetailReposAsync(long? id)
    {
        var socialMediaProfile = await _dbContext.SocialMediaProfiles.FindAsync(id);
        if (socialMediaProfile != null)
        {
            _dbContext.SocialMediaProfiles.Remove(socialMediaProfile);
        }
        await _dbContext.SaveChangesAsync();
    }
}
