using IFC.Application.DTOs.RelationType;

namespace IFC.Application.Contracts.Persistence.Repositries;

public interface IRelationTypeRepo
{
    Task CreateRelationTypeDetailAsync(RelationType relationType);
    Task DeleteRelationTypeDetailAsync(long? id);
    Task<List<RelationTypeDTO>> GetRelationTypeDetailsAsync();
    Task<RelationTypeDTO> GetRelationTypeDetailsAsync(long? id);
}