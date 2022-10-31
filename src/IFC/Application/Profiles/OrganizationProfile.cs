using IFC.Application.DTOs.Organization;
using Mapster;

namespace IFC.Application.Profiles;
internal class OrganizationProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        TypeAdapterConfig<Organization, OrganizationDTO>
        .NewConfig()
        .Map(dest => dest.LocalAffiliate, src => $"{src.Affiliate!.LocalAffiliate}")
        .Map(dest => dest.ForeignAffiliate, src => $"{src.Affiliate!.ForeignAffiliate}")
        .Map(dest => dest.OperationalBase, src => $"{src.OperationalBase!.Name}")
        .Map(dest => dest.SocialMediaProfile, src => $"{src.SocialMediaProfile!.Name}");
    }
}