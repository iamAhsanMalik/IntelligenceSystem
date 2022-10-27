namespace IFC.Infrastructure.Persistence.Repositories;

public interface IFunderRepo
{
    Task CreateFunderAsync(Funder funder);
    Task DeleteFunderAsync(long? id);
    Task<List<Funder>> GetFundersAsync();
    Task<Funder?> GetFundersAsync(long? id);
}