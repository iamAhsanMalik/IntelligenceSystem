using IFC.Application.DTOs.Affiliate;

namespace IFC.Application.Contracts.Persistence.Repositries;

public interface IAffiliateRepo
{
    Task CreateAffiliateAsync(Affiliate affiliate);
    Task DeleteAffiliateAsync(long? id);
    Task<List<AffiliateDTO>> GetAffiliatesAsync();
    Task<AffiliateDTO> GetAffiliatesAsync(long? id);
}