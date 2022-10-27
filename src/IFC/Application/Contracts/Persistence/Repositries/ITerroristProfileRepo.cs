namespace IFC.Application.Contracts.Persistence.Repositries;

public interface ITerroristProfileRepo
{
    Task CreateTerroristProfilesAsync(TerroristProfile TerroristProfiles);
    Task DeleteTerroristProfilesAsync(long? id);
    Task<List<TerroristProfile>> GetTerroristProfilesAsync();
    Task<TerroristProfile?> GetTerroristProfilesAsync(long? id);
}