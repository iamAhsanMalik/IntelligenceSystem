using IFC.Application.DTOs.SocialMediaProfile;

namespace IFC.Application.Contracts.Persistence.Repositries;

public interface ISocialMediaProfileRepo
{
    Task CreateSocialMediaProfileDetailAsync(SocialMediaProfile socialMediaProfile);
    Task DeleteSocialMediaProfileDetailAsync(long? id);
    Task<List<SocialMediaProfileDTO>> GetSocialMediaProfileDetailsAsync();
    Task<SocialMediaProfileDTO> GetSocialMediaProfileDetailsAsync(long? id);
}