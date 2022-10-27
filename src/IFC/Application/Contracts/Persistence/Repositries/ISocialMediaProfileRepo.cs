namespace IFC.Application.Contracts.Persistence.Repositries;

public interface ISocialMediaProfileRepo
{
    Task CreateSocialMediaProfileDetailAsync(SocialMediaProfile socialMediaProfile);
    Task DeleteSocialMediaProfileDetailReposAsync(long? id);
    Task<List<SocialMediaProfile>> GetSocialMediaProfileDetailReposAsync();
    Task<SocialMediaProfile?> GetSocialMediaProfileDetailReposAsync(long? id);
}