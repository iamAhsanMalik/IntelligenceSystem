using IFC.Application.Contracts.Persistence.Repositries;
using IFC.Application.DTOs.Organization;

namespace IFC.Infrastructure.Persistence.Repositories;

public class OrganizationRepo : IOrganizationRepo
{
    private readonly IFCDbContext _dbContext;
    private readonly IMapper _mapper;

    public OrganizationRepo(IFCDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<OrganizationDTO>> GetOrganizationDetailReposAsync()
    {
        return _mapper.Map<List<OrganizationDTO>>(await _dbContext.Organizations.Include(o => o.Affiliate).Include(o => o.Involvement).Include(o => o.OperationalBase).Include(o => o.SocialMediaProfile).ToListAsync());

    }
    public async Task<OrganizationDTO> GetOrganizationDetailReposAsync(long? id)
    {
        var result = await _dbContext.Organizations
            .Include(o => o.Affiliate)
            .Include(o => o.Involvement)
            .Include(o => o.OperationalBase)
            .Include(o => o.SocialMediaProfile)
            .FirstOrDefaultAsync(m => m.Id == id);
        return _mapper.Map<OrganizationDTO>(result!);

    }
    public async Task CreateOrganizationDetailAsync(Organization organization)
    {
        _dbContext.Add(organization);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteOrganizationDetailReposAsync(long? id)
    {
        var organization = await _dbContext.Organizations.FindAsync(id);
        if (organization != null)
        {
            _dbContext.Organizations.Remove(organization);
        }
        await _dbContext.SaveChangesAsync();
    }

}
