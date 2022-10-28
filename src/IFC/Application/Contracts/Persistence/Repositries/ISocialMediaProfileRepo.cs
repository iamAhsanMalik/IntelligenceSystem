using IFC.Application.DTOs.SocialMediaProfile;

namespace IFC.Application.Contracts.Persistence.Repositries;

public interface ISocialMediaProfileRepo
{
    Task CreateSocialMediaProfileDetailAsync(SocialMediaProfile socialMediaProfile);
    Task DeleteSocialMediaProfileDetailReposAsync(long? id);
    Task<List<SocialMediaProfileDTO>> GetSocialMediaProfileDetailReposAsync();
    Task<SocialMediaProfileDTO> GetSocialMediaProfileDetailReposAsync(long? id);
}