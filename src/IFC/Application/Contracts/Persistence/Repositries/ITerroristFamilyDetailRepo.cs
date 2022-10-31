using IFC.Application.DTOs.TerroristFamilyDetail;

namespace IFC.Application.Contracts.Persistence.Repositries;

public interface ITerroristFamilyDetailRepo
{
    Task CreateTerroristFamilyDetailAsync(TerroristFamilyDetail terroristFamilyDetail);
    Task DeleteTerroristFamilyDetailAsync(long? id);
    Task<List<TerroristFamilyDetailDTO>> GetTerroristFamilyDetailsAsync();
    Task<TerroristFamilyDetailDTO> GetTerroristFamilyDetailsAsync(long? id);
}