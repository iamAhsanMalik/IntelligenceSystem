namespace IFC.Application.Contracts.Persistence.Repositries;

public interface IInvolvementRepo
{
    Task CreateInvolvementAsync(Involvement involvement);
    Task DeleteInvolvementAsync(long? id);
    Task<List<Involvement>> GetInvolvementsAsync();
    Task<Involvement?> GetInvolvementsAsync(long? id);
}