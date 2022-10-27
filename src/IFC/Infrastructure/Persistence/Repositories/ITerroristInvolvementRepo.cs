namespace IFC.Infrastructure.Persistence.Repositories;

public interface ITerroristInvolvementRepo
{
    Task CreateTerroristInvolvementsAsync(TerroristInvolvement TerroristInvolvements);
    Task DeleteTerroristInvolvementsAsync(long? id);
    Task<List<TerroristInvolvement>> GetTerroristInvolvementsAsync();
    Task<TerroristInvolvement?> GetTerroristInvolvementsAsync(long? id);
}