using IFC.Application.DTOs.OperationalBase;

namespace IFC.Application.Contracts.Persistence.Repositries;

public interface IOperationalBaseRepo
{
    Task CreateOperationalBaseDetailAsync(OperationalBase operationalBase);
    Task DeleteOperationalBaseDetailAsync(long? id);
    Task<List<OperationalBaseDTO>> GetOperationalBaseDetailsAsync();
    Task<OperationalBaseDTO> GetOperationalBaseDetailsAsync(long? id);
}