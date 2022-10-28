using IFC.Application.DTOs.Wing;

namespace IFC.Application.Contracts.Persistence.Repositries;

public interface IWingRepo
{
    Task CreateWingsAsync(Wing wing);
    Task DeleteWingsAsync(long? id);
    Task<List<WingDTO>> GetWingsAsync();
    Task<WingDTO> GetWingsAsync(long? id);
}