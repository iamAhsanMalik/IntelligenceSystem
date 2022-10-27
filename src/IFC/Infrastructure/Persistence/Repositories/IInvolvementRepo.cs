namespace IFC.Infrastructure.Persistence.Repositories;

public interface IInvolvementRepo
{
    Task CreateInvolvementAsync(Involvement involvement);
    Task DeleteInvolvementAsync(long? id);
    Task<List<Involvement>> GetInvolvementsAsync();
    Task<Involvement?> GetInvolvementsAsync(long? id);
}