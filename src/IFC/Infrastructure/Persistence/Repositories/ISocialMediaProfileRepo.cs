namespace IFC.Infrastructure.Persistence.Repositories;

public interface ISocialMediaProfileRepo
{
    Task CreateSocialMediaProfileDetailAsync(SocialMediaProfile socialMediaProfile);
    Task DeleteSocialMediaProfileDetailReposAsync(long? id);
    Task<List<SocialMediaProfile>> GetSocialMediaProfileDetailReposAsync();
    Task<SocialMediaProfile?> GetSocialMediaProfileDetailReposAsync(long? id);
}