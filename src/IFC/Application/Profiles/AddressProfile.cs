using IFC.Application.DTOs.Address;
using Mapster;

namespace IFC.Application.Profiles;
internal class AddressProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        TypeAdapterConfig<Address, AddressDTO>
        .NewConfig()
        .Map(dest => dest.City, src => $"{src.City!.Name}")
        .Map(dest => dest.District, src => $"{src.District!.Name}");
    }
}