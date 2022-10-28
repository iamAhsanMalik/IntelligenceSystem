namespace IFC.Application.Contracts.Persistence.Repositries;

public interface ITerroristInvolvementRepo
{
    Task CreateTerroristInvolvementAsync(TerroristInvolvement TerroristInvolvements);
    Task DeleteTerroristInvolvementAsync(long? id);
    Task<List<TerroristInvolvement>> GetTerroristInvolvementsAsync();
    Task<TerroristInvolvement?> GetTerroristInvolvementsAsync(long? id);
}