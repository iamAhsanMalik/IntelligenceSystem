using IFC.Application.DTOs.Approval;
using Mapster;

namespace IFC.Application.Profiles;
internal class ApprovalProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        TypeAdapterConfig<Approval, ApprovalDTO>
        .NewConfig()
        .Map(dest => dest.ApprovalRequestType, src => $"{src.ApprovalRequestType!.RequestType}");
    }
}