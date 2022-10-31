using IFC.Application.DTOs.Funder;

namespace IFC.Application.Contracts.Persistence.Repositries;

public interface IFunderRepo
{
    Task CreateFunderAsync(Funder funder);
    Task DeleteFunderAsync(long? id);
    Task<List<FunderDTO>> GetFundersAsync();
    Task<FunderDTO> GetFundersAsync(long? id);
}