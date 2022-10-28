using IFC.Application.DTOs.TerroristProfile;

namespace IFC.Application.Contracts.Persistence.Repositries;

public interface ITerroristProfileRepo
{
    Task CreateTerroristProfilesAsync(TerroristProfile TerroristProfiles);
    Task DeleteTerroristProfilesAsync(long? id);
    Task<List<TerroristProfileDTO>> GetTerroristProfilesAsync();
    Task<TerroristProfileDTO> GetTerroristProfilesAsync(long? id);
}