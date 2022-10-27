namespace IFC.Application.Contracts.Persistence.Repositries;

public interface ITerroristInvolvementRepo
{
    Task CreateTerroristInvolvementsAsync(TerroristInvolvement TerroristInvolvements);
    Task DeleteTerroristInvolvementsAsync(long? id);
    Task<List<TerroristInvolvement>> GetTerroristInvolvementsAsync();
    Task<TerroristInvolvement?> GetTerroristInvolvementsAsync(long? id);
}