using IFC.Application.Contracts.Persistence.Repositries;

namespace IFC.Infrastructure.Persistence.Repositories;

public class RelationTypeRepo : IRelationTypeRepo
{
    private readonly IFCDbContext _dbContext;
    public RelationTypeRepo(IFCDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<RelationType>> GetRelationTypeDetailReposAsync()
    {
        var iFCDbContext = await _dbContext.RelationTypes.ToListAsync();

        return iFCDbContext;
    }
    public async Task<RelationType?> GetRelationTypeDetailReposAsync(long? id)
    {
        return await _dbContext.RelationTypes
            .FirstOrDefaultAsync(m => m.Id == id);

    }
    public async Task CreateRelationTypeDetailAsync(RelationType relationType)
    {
        _dbContext.Add(relationType);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteRelationTypeDetailReposAsync(long? id)
    {
        var relationType = await _dbContext.RelationTypes.FindAsync(id);
        if (relationType != null)
        {
            _dbContext.RelationTypes.Remove(relationType);
        }
        await _dbContext.SaveChangesAsync();
    }
}
