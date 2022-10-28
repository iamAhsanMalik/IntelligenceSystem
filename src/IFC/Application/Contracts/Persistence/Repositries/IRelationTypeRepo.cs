using IFC.Application.DTOs.RelationType;

namespace IFC.Application.Contracts.Persistence.Repositries;

public interface IRelationTypeRepo
{
    Task CreateRelationTypeDetailAsync(RelationType relationType);
    Task DeleteRelationTypeDetailReposAsync(long? id);
    Task<List<RelationTypeDTO>> GetRelationTypeDetailReposAsync();
    Task<RelationTypeDTO> GetRelationTypeDetailReposAsync(long? id);
}