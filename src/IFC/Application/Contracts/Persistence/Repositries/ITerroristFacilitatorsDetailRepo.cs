namespace IFC.Application.Contracts.Persistence.Repositries;

public interface ITerroristFacilitatorsDetailRepo
{
    Task CreateTerroristFacilitatorsDetailAsync(TerroristFacilitatorsDetail terroristFacilitatorsDetail);
    Task DeleteTerroristFacilitatorsDetailAsync(long? id);
    Task<List<TerroristFacilitatorsDetail>> GetTerroristFacilitatorsDetailsAsync();
    Task<TerroristFacilitatorsDetail?> GetTerroristFacilitatorsDetailsAsync(long? id);
}