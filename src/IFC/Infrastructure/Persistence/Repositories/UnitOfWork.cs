using IFC.Application.Contracts.Persistence.Repositries;

namespace IFC.Infrastructure.Persistence.Repositories;

internal class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(IAddressRepo addressRepo, IAffiliateRepo affiliateRepo, IApprovalRepo approvalRepo, IApprovalRequestTypeRepo approvalRequestTypeRepo, ICityRepo cityRepo, ICoreHeadQuarterRepo coreHeadQuarterRepo, IDistrictRepo districtRepo, IFunderRepo funderRepo, IIncidentRepo incidentRepo, IInvolvementRepo involvementRepo, ILocationRepo locationRepo, IOperationalBaseRepo operationalBaseRepo, IOrganizationRepo organizationRepo, IRelationTypeRepo relationTypeRepo, ISectorHeadQuarterRepo sectorHeadQuarterRepo, ISocialMediaProfileRepo socialMediaProfileRepo, ITerroristFacilitatorsDetailRepo terroristFacilitatorsDetailRepo, ITerroristFamilyDetailRepo terroristFamilyDetailRepo, ITerroristInvolvementRepo terroristInvolvementRepo, ITerroristProfileRepo terroristProfileRepo, IThreatRepo threatRepo, IWingRepo wingRepo)
    {
        AddressRepo = addressRepo;
        AffiliateRepo = affiliateRepo;
        ApprovalRepo = approvalRepo;
        ApprovalRequestTypeRepo = approvalRequestTypeRepo;
        CityRepo = cityRepo;
        CoreHeadQuarterRepo = coreHeadQuarterRepo;
        DistrictRepo = districtRepo;
        FunderRepo = funderRepo;
        IncidentRepo = incidentRepo;
        InvolvementRepo = involvementRepo;
        LocationRepo = locationRepo;
        OperationalBaseRepo = operationalBaseRepo;
        OrganizationRepo = organizationRepo;
        RelationTypeRepo = relationTypeRepo;
        SectorHeadQuarterRepo = sectorHeadQuarterRepo;
        SocialMediaProfileRepo = socialMediaProfileRepo;
        TerroristFacilitatorsDetailRepo = terroristFacilitatorsDetailRepo;
        TerroristFamilyDetailRepo = terroristFamilyDetailRepo;
        TerroristInvolvementRepo = terroristInvolvementRepo;
        TerroristProfileRepo = terroristProfileRepo;
        ThreatRepo = threatRepo;
        WingRepo = wingRepo;
    }
    public IAddressRepo AddressRepo { get; private set; }
    public IAffiliateRepo AffiliateRepo { get; private set; }
    public IApprovalRepo ApprovalRepo { get; private set; }
    public IApprovalRequestTypeRepo ApprovalRequestTypeRepo { get; private set; }
    public ICityRepo CityRepo { get; private set; }
    public ICoreHeadQuarterRepo CoreHeadQuarterRepo { get; private set; }
    public IDistrictRepo DistrictRepo { get; private set; }
    public IFunderRepo FunderRepo { get; private set; }
    public IIncidentRepo IncidentRepo { get; private set; }
    public IInvolvementRepo InvolvementRepo { get; private set; }
    public ILocationRepo LocationRepo { get; private set; }
    public IOperationalBaseRepo OperationalBaseRepo { get; private set; }
    public IOrganizationRepo OrganizationRepo { get; private set; }
    public IRelationTypeRepo RelationTypeRepo { get; private set; }
    public ISectorHeadQuarterRepo SectorHeadQuarterRepo { get; private set; }
    public ISocialMediaProfileRepo SocialMediaProfileRepo { get; private set; }
    public ITerroristFacilitatorsDetailRepo TerroristFacilitatorsDetailRepo { get; private set; }
    public ITerroristFamilyDetailRepo TerroristFamilyDetailRepo { get; private set; }
    public ITerroristInvolvementRepo TerroristInvolvementRepo { get; private set; }
    public ITerroristProfileRepo TerroristProfileRepo { get; private set; }
    public IThreatRepo ThreatRepo { get; private set; }
    public IWingRepo WingRepo { get; private set; }
}
