using IFC.Application.DTOs.TerroristInvolvement;

namespace IFC.Application.Contracts.Persistence.Repositries;

public interface ITerroristInvolvementRepo
{
    Task CreateTerroristInvolvementAsync(TerroristInvolvement TerroristInvolvements);
    Task DeleteTerroristInvolvementAsync(long? id);
    Task<List<TerroristInvolvementDTO>> GetTerroristInvolvementsAsync();
    Task<TerroristInvolvementDTO> GetTerroristInvolvementsAsync(long? id);
}