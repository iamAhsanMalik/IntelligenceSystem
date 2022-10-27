namespace IFC.Application.Contracts.Persistence.Repositries;

public interface IAddressRepo
{
    Task CreateAddressAsync(Address address);
    Task DeleteAddressAsync(long? id);
    Task<List<Address>> GetAddressesAsync();
    Task<Address?> GetAddressesAsync(long? id);
}