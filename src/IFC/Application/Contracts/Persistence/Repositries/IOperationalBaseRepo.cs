using IFC.Application.DTOs.OperationalBase;

namespace IFC.Application.Contracts.Persistence.Repositries;

public interface IOperationalBaseRepo
{
    Task CreateOperationalBaseDetailAsync(OperationalBase operationalBase);
    Task DeleteOperationalBaseDetailReposAsync(long? id);
    Task<List<OperationalBaseDTO>> GetOperationalBaseDetailReposAsync();
    Task<OperationalBaseDTO> GetOperationalBaseDetailReposAsync(long? id);
}