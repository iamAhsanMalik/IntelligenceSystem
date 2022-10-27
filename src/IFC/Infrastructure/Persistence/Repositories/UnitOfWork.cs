using IFC.Application.Contracts.Persistence.Repositries;

namespace IFC.Infrastructure.Persistence.Repositories;

internal class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(IFCDbContext dbContext)
    {
        AddressRepo = new AddressRepo(dbContext);
        AffiliateRepo = new AffiliateRepo(dbContext);
        ApprovalRepo = new ApprovalRepo(dbContext);
        ApprovalRequestTypeRepo = new ApprovalRequestTypeRepo(dbContext);
        CityRepo = new CityRepo(dbContext);
        CoreHeadQuarterRepo = new CoreHeadQuarterRepo(dbContext);
        DistrictRepo = new DistrictRepo(dbContext);
        FunderRepo = new FunderRepo(dbContext);
        IncidentRepo = new IncidentRepo(dbContext);
        InvolvementRepo = new InvolvementRepo(dbContext);
        LocationRepo = new LocationRepo(dbContext);
        OperationalBaseRepo = new OperationalBaseRepo(dbContext);
        OrganizationRepo = new OrganizationRepo(dbContext);
        RelationTypeRepo = new RelationTypeRepo(dbContext);
        SectorHeadQuarterRepo = new SectorHeadQuarterRepo(dbContext);
        SocialMediaProfileRepo = new SocialMediaProfileRepo(dbContext);
        TerroristFacilitatorsDetailRepo = new TerroristFacilitatorsDetailRepo(dbContext);
        TerroristFamilyDetailRepo = new TerroristFamilyDetailRepo(dbContext);
        TerroristInvolvementRepo = new TerroristInvolvementRepo(dbContext);
        TerroristProfileRepo = new TerroristProfileRepo(dbContext);
        ThreatRepo = new ThreatRepo(dbContext);
        WingRepo = new WingRepo(dbContext);
    }

    //public UnitOfWork(IAddressRepo addressRepo, IAffiliateRepo affiliateRepo, IApprovalRepo approvalRepo, IApprovalRequestTypeRepo approvalRequestTypeRepo, ICityRepo cityRepo, ICoreHeadQuarterRepo coreHeadQuarterRepo, IDistrictRepo districtRepo, IFunderRepo funderRepo, IIncidentRepo incidentRepo, IInvolvementRepo involvementRepo, ILocationRepo locationRepo, IOperationalBaseRepo operationalBaseRepo, IOrganizationRepo organizationRepo, IRelationTypeRepo relationTypeRepo, ISectorHeadQuarterRepo sectorHeadQuarterRepo, ISocialMediaProfileRepo socialMediaProfileRepo, ITerroristFacilitatorsDetailRepo terroristFacilitatorsDetailRepo, ITerroristFamilyDetailRepo terroristFamilyDetailRepo, ITerroristInvolvementRepo terroristInvolvementRepo, ITerroristProfileRepo terroristProfileRepo, IThreatRepo threatRepo, IWingRepo wingRepo)
    //{
    //    AddressRepo = addressRepo;
    //    AffiliateRepo = affiliateRepo;
    //    ApprovalRepo = approvalRepo;
    //    ApprovalRequestTypeRepo = approvalRequestTypeRepo;
    //    CityRepo = cityRepo;
    //    CoreHeadQuarterRepo = coreHeadQuarterRepo;
    //    DistrictRepo = districtRepo;
    //    FunderRepo = funderRepo;
    //    IncidentRepo = incidentRepo;
    //    InvolvementRepo = involvementRepo;
    //    LocationRepo = locationRepo;
    //    OperationalBaseRepo = operationalBaseRepo;
    //    OrganizationRepo = organizationRepo;
    //    RelationTypeRepo = relationTypeRepo;
    //    SectorHeadQuarterRepo = sectorHeadQuarterRepo;
    //    SocialMediaProfileRepo = socialMediaProfileRepo;
    //    TerroristFacilitatorsDetailRepo = terroristFacilitatorsDetailRepo;
    //    TerroristFamilyDetailRepo = terroristFamilyDetailRepo;
    //    TerroristInvolvementRepo = terroristInvolvementRepo;
    //    TerroristProfileRepo = terroristProfileRepo;
    //    ThreatRepo = threatRepo;
    //    WingRepo = wingRepo;
    //}
    public IAddressRepo AddressRepo { get; }
    public IAffiliateRepo AffiliateRepo { get; }
    public IApprovalRepo ApprovalRepo { get; }
    public IApprovalRequestTypeRepo ApprovalRequestTypeRepo { get; }
    public ICityRepo CityRepo { get; }
    public ICoreHeadQuarterRepo CoreHeadQuarterRepo { get; }
    public IDistrictRepo DistrictRepo { get; }
    public IFunderRepo FunderRepo { get; }
    public IIncidentRepo IncidentRepo { get; }
    public IInvolvementRepo InvolvementRepo { get; }
    public ILocationRepo LocationRepo { get; }
    public IOperationalBaseRepo OperationalBaseRepo { get; }
    public IOrganizationRepo OrganizationRepo { get; }
    public IRelationTypeRepo RelationTypeRepo { get; }
    public ISectorHeadQuarterRepo SectorHeadQuarterRepo { get; }
    public ISocialMediaProfileRepo SocialMediaProfileRepo { get; }
    public ITerroristFacilitatorsDetailRepo TerroristFacilitatorsDetailRepo { get; private set; }
    public ITerroristFamilyDetailRepo TerroristFamilyDetailRepo { get; private set; }
    public ITerroristInvolvementRepo TerroristInvolvementRepo { get; private set; }
    public ITerroristProfileRepo TerroristProfileRepo { get; private set; }
    public IThreatRepo ThreatRepo { get; private set; }
    public IWingRepo WingRepo { get; private set; }
}
