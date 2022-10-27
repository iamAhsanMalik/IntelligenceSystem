namespace IFC.Application.Contracts.Persistence.Repositries;

public interface IFunderRepo
{
    Task CreateFunderAsync(Funder funder);
    Task DeleteFunderAsync(long? id);
    Task<List<Funder>> GetFundersAsync();
    Task<Funder?> GetFundersAsync(long? id);
}