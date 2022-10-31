using IFC.Application.DTOs.Involvement;

namespace IFC.Application.Contracts.Persistence.Repositries;

public interface IInvolvementRepo
{
    Task CreateInvolvementAsync(Involvement involvement);
    Task DeleteInvolvementAsync(long? id);
    Task<List<InvolvementDTO>> GetInvolvementsAsync();
    Task<InvolvementDTO> GetInvolvementsAsync(long? id);
}