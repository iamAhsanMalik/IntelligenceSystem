namespace IFC.Infrastructure.Persistence.Repositories;

public interface IRelationTypeRepo
{
    Task CreateRelationTypeDetailAsync(RelationType relationType);
    Task DeleteRelationTypeDetailReposAsync(long? id);
    Task<List<RelationType>> GetRelationTypeDetailReposAsync();
    Task<RelationType?> GetRelationTypeDetailReposAsync(long? id);
}