using IFC.Application.DTOs.OrganizationFunder;
using Mapster;

namespace IFC.Application.Profiles;
internal class OrganizationFunderProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        TypeAdapterConfig<OrganizationFunder, OrganizationFunderDTO>
        .NewConfig()
        .Map(dest => dest.Organization, src => $"{src.Organization!.Name}")
        .Map(dest => dest.Funder, src => $"{src.Funder!.Name}");
    }
}