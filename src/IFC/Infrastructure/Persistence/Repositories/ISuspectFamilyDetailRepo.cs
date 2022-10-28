using IFC.Application.DTOs.SuspectFamilyDetail;

namespace IFC.Infrastructure.Persistence.Repositories;
public interface ISuspectFamilyDetailRepo
{
    Task CreateSuspectFamilyDetailAsync(SuspectFamilyDetail suspectFamilyDetail);
    Task DeleteSuspectFamilyDetailAsync(long? id);
    Task<List<SuspectFamilyDetailDTO>> GetSuspectFamilyDetailsAsync();
    Task<SuspectFamilyDetailDTO> GetSuspectFamilyDetailsAsync(long? id);
}