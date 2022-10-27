using IFC.Application.Contracts.Persistence.Repositries;

namespace IFC.Infrastructure.Persistence.Repositories;

public class TerroristInvolvementRepo : ITerroristInvolvementRepo
{
    private readonly IFCDbContext _dbContext;
    public TerroristInvolvementRepo(IFCDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<TerroristInvolvement>> GetTerroristInvolvementsAsync()
    {
        var iFCDbContext = await _dbContext.TerroristInvolvements.ToListAsync());

        return iFCDbContext;
    }
    public async Task<TerroristInvolvement?> GetTerroristInvolvementsAsync(long? id)
    {
        return await _dbContext.TerroristInvolvements
            .FirstOrDefaultAsync(m => m.Id == id);

    }
    public async Task CreateTerroristInvolvementsAsync(TerroristInvolvement TerroristInvolvements)
    {
        _dbContext.Add(TerroristInvolvements);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteTerroristInvolvementsAsync(long? id)
    {
        var TerroristInvolvement = await _dbContext.TerroristInvolvements.FindAsync(id);
        if (TerroristInvolvement != null)
        {
            _dbContext.TerroristInvolvements.Remove(TerroristInvolvement);
        }
        await _dbContext.SaveChangesAsync();
    }
}
