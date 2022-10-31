using IFC.Application.DTOs.TerroristFamilyDetail;
using Mapster;

namespace IFC.Application.Profiles;
internal class TerroristFamilyDetailProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        TypeAdapterConfig<TerroristFamilyDetail, TerroristFamilyDetailDTO>
        .NewConfig()
        .Map(dest => dest.RelationType, src => $"{src.RelationType!.Name}");
    }
}