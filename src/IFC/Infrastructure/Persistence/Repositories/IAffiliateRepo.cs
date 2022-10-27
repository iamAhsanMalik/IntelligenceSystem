namespace IFC.Infrastructure.Persistence.Repositories;

public interface IAffiliateRepo
{
    Task CreateAffiliatesAsync(Affiliate affiliate);
    Task DeleteAffiliatesAsync(long? id);
    Task<List<Affiliate>> GetAffiliatesAsync();
    Task<Affiliate?> GetAffiliatesAsync(long? id);
}