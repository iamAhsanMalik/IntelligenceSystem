namespace IFC.Infrastructure.Persistence.Repositories;

public class OrganizationRepo
{
    private readonly IFCDbContext _dbContext;
    public OrganizationRepo(IFCDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Organization>> GetOrganizationDetailReposAsync()
    {
        var iFCDbContext = await _dbContext.Organizations.Include(o => o.Affiliate).Include(o => o.Involvement).Include(o => o.OperationalBase).Include(o => o.SocialMediaProfile).ToListAsync();

        return iFCDbContext;
    }
    public async Task<Organization?> GetOrganizationDetailReposAsync(long? id)
    {
        return await _dbContext.Organizations
            .Include(o => o.Affiliate)
            .Include(o => o.Involvement)
            .Include(o => o.OperationalBase)
            .Include(o => o.SocialMediaProfile)
            .FirstOrDefaultAsync(m => m.Id == id);

    }
    public async Task CreateOrganizationDetailAsync(Organization  organization)
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
