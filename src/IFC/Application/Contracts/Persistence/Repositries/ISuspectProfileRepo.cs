using IFC.Application.DTOs.SuspectFamilyDetail;

namespace IFC.Application.Contracts.Persistence.Repositries;
public interface ISuspectProfileRepo
{
    Task CreateSuspectFamilyDetailAsync(SuspectFamilyDetail suspectFamilyDetail);
    Task DeleteSuspectFamilyDetailAsync(long? id);
    Task<List<SuspectFamilyDetailDTO>> GetSuspectFamilyDetailsAsync();
    Task<SuspectFamilyDetailDTO> GetSuspectFamilyDetailsAsync(long? id);
}