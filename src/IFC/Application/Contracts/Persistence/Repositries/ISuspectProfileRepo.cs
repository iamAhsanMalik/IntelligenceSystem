using IFC.Application.DTOs.SuspectProfile;

namespace IFC.Application.Contracts.Persistence.Repositries;
public interface ISuspectProfileRepo
{
    Task CreateSuspectProfileAsync(SuspectProfile suspectProfile);
    Task DeleteSuspectProfileAsync(long? id);
    Task<List<SuspectProfileDTO>> GetSuspectProfilesAsync();
    Task<SuspectProfileDTO> GetSuspectProfilesAsync(long? id);
}