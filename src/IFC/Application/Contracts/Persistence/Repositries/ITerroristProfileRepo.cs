using IFC.Application.DTOs.TerroristProfile;

namespace IFC.Application.Contracts.Persistence.Repositries;

public interface ITerroristProfileRepo
{
    Task CreateTerroristProfileAsync(TerroristProfile TerroristProfiles);
    Task DeleteTerroristProfileAsync(long? id);
    Task<List<TerroristProfileDTO>> GetTerroristProfilesAsync();
    Task<TerroristProfileDTO> GetTerroristProfilesAsync(long? id);
}