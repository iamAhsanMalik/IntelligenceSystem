using IFC.Application.DTOs.Affiliate;

namespace IFC.Application.Contracts.Persistence.Repositries;

public interface IAffiliateRepo
{
    Task CreateAffiliatesAsync(Affiliate affiliate);
    Task DeleteAffiliatesAsync(long? id);
    Task<List<AffiliateDTO>> GetAffiliatesAsync();
    Task<AffiliateDTO> GetAffiliatesAsync(long? id);
}