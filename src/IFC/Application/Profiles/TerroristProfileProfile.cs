using Mapster;

namespace IFC.Application.Profiles;
internal class TerroristProfileProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        //TypeAdapterConfig<ThreatProfile, ThreatDTO>
        //.NewConfig()
        //.Map(dest => dest.Organization, src => $"{src.Organization!.Name}")
        //.Map(dest => dest.Wing, src => $"{src.Wing!.Name}")
        //.Map(dest => dest.SuspectsProfile, src => $"{src.SuspectsProfile!.FullName}")
        //.Map(dest => dest.Incident, src => $"{src.Incident!.IncidentDate}")
        //.Map(dest => dest.Location, src => $"{src.Location!.Name}");
    }
}