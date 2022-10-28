using IFC.Application.DTOs.Organization;

namespace IFC.Application.Contracts.Persistence.Repositries;

public interface IOrganizationRepo
{
    Task CreateOrganizationDetailAsync(Organization organization);
    Task DeleteOrganizationDetailReposAsync(long? id);
    Task<List<OrganizationDTO>> GetOrganizationDetailReposAsync();
    Task<OrganizationDTO> GetOrganizationDetailReposAsync(long? id);
}