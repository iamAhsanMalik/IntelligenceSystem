namespace IFC.Application.Contracts.Persistence.Repositries;

public interface IRelationTypeRepo
{
    Task CreateRelationTypeDetailAsync(RelationType relationType);
    Task DeleteRelationTypeDetailReposAsync(long? id);
    Task<List<RelationType>> GetRelationTypeDetailReposAsync();
    Task<RelationType?> GetRelationTypeDetailReposAsync(long? id);
}