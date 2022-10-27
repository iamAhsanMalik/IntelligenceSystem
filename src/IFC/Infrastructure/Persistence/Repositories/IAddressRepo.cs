namespace IFC.Infrastructure.Persistence.Repositories;

public interface IAddressRepo
{
    Task CreateAddressAsync(Address address);
    Task DeleteAddressAsync(long? id);
    Task<List<Address>> GetAddressesAsync();
    Task<Address?> GetAddressesAsync(long? id);
}