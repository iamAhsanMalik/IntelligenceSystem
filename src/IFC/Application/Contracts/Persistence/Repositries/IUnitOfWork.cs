namespace IFC.Application.Contracts.Persistence.Repositries;
public interface IUnitOfWork
{
    IAddressRepo AddressRepo { get; }
    IAffiliateRepo AffiliateRepo { get; }
    IApprovalRepo ApprovalRepo { get; }
    IApprovalRequestTypeRepo ApprovalRequestTypeRepo { get; }
    ICityRepo CityRepo { get; }
    ICoreHeadQuarterRepo CoreHeadQuarterRepo { get; }
    IDistrictRepo DistrictRepo { get; }
    IFunderRepo FunderRepo { get; }
    IIncidentRepo IncidentRepo { get; }
    IInvolvementRepo InvolvementRepo { get; }
    ILocationRepo LocationRepo { get; }
    IOperationalBaseRepo OperationalBaseRepo { get; }
    IOrganizationRepo OrganizationRepo { get; }
    IRelationTypeRepo RelationTypeRepo { get; }
    ISectorHeadQuarterRepo SectorHeadQuarterRepo { get; }
    ISocialMediaProfileRepo SocialMediaProfileRepo { get; }
    ITerroristFacilitatorsDetailRepo TerroristFacilitatorsDetailRepo { get; }
    ITerroristFamilyDetailRepo TerroristFamilyDetailRepo { get; }
    ITerroristInvolvementRepo TerroristInvolvementRepo { get; }
    ITerroristProfileRepo TerroristProfileRepo { get; }
    IThreatRepo ThreatRepo { get; }
    IWingRepo WingRepo { get; }
    ISuspectFamilyDetailRepo SuspectFamilyDetailRepo { get; }
    ISuspectProfileRepo SuspectProfileRepo { get; }
    IDbHelpers DbHelpers { get; }
}