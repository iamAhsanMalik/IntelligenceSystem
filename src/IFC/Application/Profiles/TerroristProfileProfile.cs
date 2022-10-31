using IFC.Application.DTOs.TerroristProfile;
using Mapster;

namespace IFC.Application.Profiles;
internal class TerroristProfileProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        TypeAdapterConfig<TerroristProfile, TerroristProfileDTO>
        .NewConfig()
        .Map(dest => dest.Organization, src => $"{src.Organization!.Name}")
        .Map(dest => dest.Address, src => $"{src.Address!.District} {src.Address!.City}")
        .Map(dest => dest.TerroristFacilitatorsDetails, src => $"{src.TerroristFacilitatorsDetails!.FullName}")
        .Map(dest => dest.TerroristFamilyDetails, src => $"{src.TerroristFamilyDetails!.FullName}")
        .Map(dest => dest.TerroristInvolvement, src => $"{src.TerroristInvolvement!.Involvement}");
    }
}