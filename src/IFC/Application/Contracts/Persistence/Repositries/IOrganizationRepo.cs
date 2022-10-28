using IFC.Application.DTOs.Organization;

namespace IFC.Application.Contracts.Persistence.Repositries;

public interface IOrganizationRepo
{
    Task CreateOrganizationDetailAsync(Organization organization);
    Task DeleteOrganizationDetailAsync(long? id);
    Task<List<OrganizationDTO>> GetOrganizationDetailsAsync();
    Task<OrganizationDTO> GetOrganizationDetailsAsync(long? id);
}