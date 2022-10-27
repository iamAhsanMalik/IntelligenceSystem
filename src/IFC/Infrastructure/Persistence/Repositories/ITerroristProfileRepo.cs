namespace IFC.Infrastructure.Persistence.Repositories;

public interface ITerroristProfileRepo
{
    Task CreateTerroristProfilesAsync(TerroristProfile TerroristProfiles);
    Task DeleteTerroristProfilesAsync(long? id);
    Task<List<TerroristProfile>> GetTerroristProfilesAsync();
    Task<TerroristProfile?> GetTerroristProfilesAsync(long? id);
}