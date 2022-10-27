namespace IFC.Application.Contracts.Persistence.Repositries;

public interface IOperationalBaseRepo
{
    Task CreateOperationalBaseDetailAsync(OperationalBase operationalBase);
    Task DeleteOperationalBaseDetailReposAsync(long? id);
    Task<List<OperationalBase>> GetOperationalBaseDetailReposAsync();
    Task<OperationalBase?> GetOperationalBaseDetailReposAsync(long? id);
}