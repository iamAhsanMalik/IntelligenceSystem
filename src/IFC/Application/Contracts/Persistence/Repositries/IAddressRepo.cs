using IFC.Application.DTOs.Address;

namespace IFC.Application.Contracts.Persistence.Repositries;

public interface IAddressRepo
{
    Task CreateAddressAsync(Address address);
    Task DeleteAddressAsync(long? id);
    Task<List<AddressDTO>> GetAddressesAsync();
    Task<AddressDTO> GetAddressesAsync(long? id);
}