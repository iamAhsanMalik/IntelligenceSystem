using IFC.Application.DTOs.TerroristInvolvement;

namespace IFC.Application.Contracts.Persistence.Repositries;

public interface ITerroristInvolvementRepo
{
    Task CreateTerroristInvolvementsAsync(TerroristInvolvement TerroristInvolvements);
    Task DeleteTerroristInvolvementsAsync(long? id);
    Task<List<TerroristInvolvementDTO>> GetTerroristInvolvementsAsync();
    Task<TerroristInvolvementDTO> GetTerroristInvolvementsAsync(long? id);
}