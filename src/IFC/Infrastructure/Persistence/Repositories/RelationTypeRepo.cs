using IFC.Application.Contracts.Persistence.Repositries;
using IFC.Application.DTOs.RelationType;

namespace IFC.Infrastructure.Persistence.Repositories;

public class RelationTypeRepo : IRelationTypeRepo
{
    private readonly IFCDbContext _dbContext;
    private readonly IMapper _mapper;

    public RelationTypeRepo(IFCDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<RelationTypeDTO>> GetRelationTypeDetailReposAsync()
    {
        return _mapper.Map<List<RelationTypeDTO>>(await _dbContext.RelationTypes.ToListAsync());

    }
    public async Task<RelationTypeDTO> GetRelationTypeDetailReposAsync(long? id)
    {
        var result = await _dbContext.RelationTypes
            .FirstOrDefaultAsync(m => m.Id == id);
        return _mapper.Map<RelationTypeDTO>(result!);
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
