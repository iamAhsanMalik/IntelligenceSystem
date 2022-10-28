using IFC.Application.DTOs.TerroristFamilyDetail;

namespace IFC.Application.Contracts.Persistence.Repositries;

public interface ITerroristFamilyDetailRepo
{
    Task CreateTerroristFamilyDetailAsync(TerroristFamilyDetail terroristFamilyDetail);
    Task DeleteTerroristFamilyDetailReposAsync(long? id);
    Task<List<TerroristFamilyDetailDTO>> GetTerroristFamilyDetailReposAsync();
    Task<TerroristFamilyDetailDTO> GetTerroristFamilyDetailReposAsync(long? id);
}