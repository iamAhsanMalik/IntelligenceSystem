using IFC.Application.DTOs.SuspectProfile;
using Mapster;

namespace IFC.Application.Profiles;
internal class SuspectProfileProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        TypeAdapterConfig<SuspectProfile, SuspectProfileDTO>
        .NewConfig()
        .Map(dest => dest.Organization, src => $"{src.Organization!.Name}")
        .Map(dest => dest.Address, src => $"{src.Address!.District} {src.Address!.City}")
        .Map(dest => dest.SuspectFamilyDetails, src => $"{src.SuspectFamilyDetails!.FullName}");
    }
}