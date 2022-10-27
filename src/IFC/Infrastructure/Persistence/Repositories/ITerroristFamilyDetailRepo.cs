namespace IFC.Infrastructure.Persistence.Repositories;

public interface ITerroristFamilyDetailRepo
{
    Task CreateTerroristFamilyDetailAsync(TerroristFamilyDetail terroristFamilyDetail);
    Task DeleteTerroristFamilyDetailReposAsync(long? id);
    Task<List<TerroristFamilyDetail>> GetTerroristFamilyDetailReposAsync();
    Task<TerroristFamilyDetail?> GetTerroristFamilyDetailReposAsync(long? id);
}