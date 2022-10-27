namespace IFC.Infrastructure.Persistence.Repositories;

public interface IWingRepo
{
    Task CreateWingsAsync(Wing wing);
    Task DeleteWingsAsync(long? id);
    Task<List<Wing>> GetWingsAsync();
    Task<Wing?> GetWingsAsync(long? id);
}