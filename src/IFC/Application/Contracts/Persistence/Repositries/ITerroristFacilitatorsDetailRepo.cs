using IFC.Application.DTOs.TerroristFacilitatorsDetail;

namespace IFC.Application.Contracts.Persistence.Repositries;

public interface ITerroristFacilitatorsDetailRepo
{
    Task CreateTerroristFacilitatorsDetailAsync(TerroristFacilitatorsDetail terroristFacilitatorsDetail);
    Task DeleteTerroristFacilitatorsDetailAsync(long? id);
    Task<List<TerroristFacilitatorsDetailDTO>> GetTerroristFacilitatorsDetailsAsync();
    Task<TerroristFacilitatorsDetailDTO> GetTerroristFacilitatorsDetailsAsync(long? id);
}