using IFC.Application.Contracts.Persistence.Repositries;

namespace IFC.Infrastructure.Persistence.Repositories;

public class AddressRepo : IAddressRepo
{
    private readonly IFCDbContext _dbContext;
    public AddressRepo(IFCDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Address>> GetAddressesAsync()
    {
        var iFCDbContext = _dbContext.Addresses.Include(a => a.City).Include(a => a.District);
        return await iFCDbContext.ToListAsync();
    }
    public async Task<Address?> GetAddressesAsync(long? id)
    {
        return await _dbContext.Addresses
            .Include(a => a.City)
            .Include(a => a.District)
            .FirstOrDefaultAsync(m => m.Id == id);
    }
    public async Task CreateAddressAsync(Address address)
    {
        _dbContext.Add(address);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteAddressAsync(long? id)
    {
        var approval = await _dbContext.Addresses.FindAsync(id);
        if (approval != null)
        {
            _dbContext.Addresses.Remove(approval);
        }
        await _dbContext.SaveChangesAsync();
    }
}
