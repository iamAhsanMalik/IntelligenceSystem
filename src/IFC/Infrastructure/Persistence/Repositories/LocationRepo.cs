using IFC.Application.Contracts.Persistence.Repositries;
using IFC.Application.DTOs.Location;

namespace IFC.Infrastructure.Persistence.Repositories;

public class LocationRepo : ILocationRepo
{
    private readonly IFCDbContext _dbContext;
    private readonly IMapper _mapper;

    public LocationRepo(IFCDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<LocationDTO>> GetLocationsAsync()
    {
        return _mapper.Map<List<LocationDTO>>(await _dbContext.Locations.ToListAsync());
    }
    public async Task<LocationDTO> GetLocationsAsync(long? id)
    {
        var result = await _dbContext.Locations.FirstOrDefaultAsync(m => m.Id == id);
        return _mapper.Map<LocationDTO>(result!);
    }
    public async Task CreateLocationAsync(Location location)
    {
        _dbContext.Add(location);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteLocationAsync(long? id)
    {
        var location = await _dbContext.Locations.FindAsync(id);
        if (location != null)
        {
            _dbContext.Locations.Remove(location);
        }
        await _dbContext.SaveChangesAsync();
    }
}
