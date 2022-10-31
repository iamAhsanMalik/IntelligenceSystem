namespace IFC.Infrastructure.Persistence.Repositories;

internal class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(IFCDbContext dbContext, IMapper mapper)
    {
        AddressRepo = new AddressRepo(dbContext, mapper);
        AffiliateRepo = new AffiliateRepo(dbContext, mapper);
        ApprovalRepo = new ApprovalRepo(dbContext, mapper);
        ApprovalRequestTypeRepo = new ApprovalRequestTypeRepo(dbContext, mapper);
        CityRepo = new CityRepo(dbContext, mapper);
        CoreHeadQuarterRepo = new CoreHeadQuarterRepo(dbContext, mapper);
        DistrictRepo = new DistrictRepo(dbContext, mapper);
        FunderRepo = new FunderRepo(dbContext, mapper);
        IncidentRepo = new IncidentRepo(dbContext, mapper);
        InvolvementRepo = new InvolvementRepo(dbContext, mapper);
        LocationRepo = new LocationRepo(dbContext, mapper);
        OperationalBaseRepo = new OperationalBaseRepo(dbContext, mapper);
        OrganizationRepo = new OrganizationRepo(dbContext, mapper);
        RelationTypeRepo = new RelationTypeRepo(dbContext, mapper);
        SectorHeadQuarterRepo = new SectorHeadQuarterRepo(dbContext, mapper);
        SocialMediaProfileRepo = new SocialMediaProfileRepo(dbContext, mapper);
        TerroristFacilitatorsDetailRepo = new TerroristFacilitatorsDetailRepo(dbContext, mapper);
        TerroristFamilyDetailRepo = new TerroristFamilyDetailRepo(dbContext, mapper);
        TerroristInvolvementRepo = new TerroristInvolvementRepo(dbContext, mapper);
        TerroristProfileRepo = new TerroristProfileRepo(dbContext, mapper);
        SuspectProfileRepo = new SuspectProfileRepo(dbContext, mapper);
        SuspectFamilyDetailRepo = new SuspectFamilyDetailRepo(dbContext, mapper);
        ThreatRepo = new ThreatRepo(dbContext, mapper);
        WingRepo = new WingRepo(dbContext, mapper);
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
    public ITerroristFacilitatorsDetailRepo TerroristFacilitatorsDetailRepo { get; }
    public ITerroristFamilyDetailRepo TerroristFamilyDetailRepo { get; }
    public ITerroristInvolvementRepo TerroristInvolvementRepo { get; }
    public ITerroristProfileRepo TerroristProfileRepo { get; }
    public ISuspectFamilyDetailRepo SuspectFamilyDetailRepo { get; }
    public ISuspectProfileRepo SuspectProfileRepo { get; }
    public IThreatRepo ThreatRepo { get; }
    public IWingRepo WingRepo { get; }
}
