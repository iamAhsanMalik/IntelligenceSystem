namespace IFC.Application.Contracts.Persistence.Repositries;

public interface IOrganizationRepo
{
    Task CreateOrganizationDetailAsync(Organization organization);
    Task DeleteOrganizationDetailReposAsync(long? id);
    Task<List<Organization>> GetOrganizationDetailReposAsync();
    Task<Organization?> GetOrganizationDetailReposAsync(long? id);
}