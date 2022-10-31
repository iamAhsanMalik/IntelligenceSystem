using IFC.Application.DTOs.Wing;
using Mapster;

namespace IFC.Application.Profiles;
internal class WingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        TypeAdapterConfig<Wing, WingDTO>
        .NewConfig()
        .Map(dest => dest.CoreHeadQuarter, src => $"{src.CoreHeadQuarter!.Name}");
    }
}