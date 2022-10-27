using IFC.Application.DTOs.TerroristFacilitatorsDetail;
using Mapster;

namespace IFC.Application.Profiles;
internal class TerroristFacilitatorsDetailProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        TypeAdapterConfig<TerroristFacilitatorsDetail, TerroristFacilitatorsDetailDTO>
        .NewConfig()
        .Map(dest => dest.RelationType, src => $"{src.RelationType!.Name}")
        .Map(dest => dest.Address, src => $"{src.Address!.District} {src.Address!.City}");
    }
}