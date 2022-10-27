namespace IFC.Infrastructure.Persistence.Repositories;

public interface IOperationalBaseRepo
{
    Task CreateOperationalBaseDetailAsync(OperationalBase operationalBase);
    Task DeleteOperationalBaseDetailReposAsync(long? id);
    Task<List<OperationalBase>> GetOperationalBaseDetailReposAsync();
    Task<OperationalBase?> GetOperationalBaseDetailReposAsync(long? id);
}