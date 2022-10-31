using IFC.Application.DTOs.CoreHeadQuarter;
using Mapster;

namespace IFC.Application.Profiles;
internal class CoreHeadQuarterProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        TypeAdapterConfig<CoreHeadQuarter, CoreHeadQuarterDTO>
        .NewConfig()
        .Map(dest => dest.SectorHeadQuarter, src => $"{src.SectorHeadQuarter!.Name}");
    }
}