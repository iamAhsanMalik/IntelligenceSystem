namespace IFC.Application.Contracts.Persistence.Repositries;

public interface ITerroristFacilitatorsDetailRepo
{
    Task CreateTerroristFacilitatorsDetailAsync(TerroristFacilitatorsDetail terroristFacilitatorsDetail);
    Task DeleteTerroristFacilitatorsDetailReposAsync(long? id);
    Task<List<TerroristFacilitatorsDetail>> GetTerroristFacilitatorsDetailReposAsync();
    Task<TerroristFacilitatorsDetail?> GetTerroristFacilitatorsDetailReposAsync(long? id);
}