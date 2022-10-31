using IFC.Application.DTOs.Address;

namespace IFC.Infrastructure.Persistence.Repositories;

public class AddressRepo : IAddressRepo
{
    private readonly IFCDbContext _dbContext;
    private readonly IMapper _mapper;

    public AddressRepo(IFCDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<AddressDTO>> GetAddressesAsync()
    {
        var iFCDbContext = _dbContext.Addresses.Include(a => a.City).Include(a => a.District);
        return _mapper.Map<List<AddressDTO>>(await iFCDbContext.ToListAsync());
    }
    public async Task<AddressDTO> GetAddressesAsync(long? id)
    {
        var address = await _dbContext.Addresses
            .Include(a => a.City)
            .Include(a => a.District)
            .FirstOrDefaultAsync(m => m.Id == id);
        return _mapper.Map<AddressDTO>(address!);
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
