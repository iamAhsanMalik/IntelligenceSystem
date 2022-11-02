using IFC.Application.Enums;

namespace IFC.Infrastructure.Persistence.Seeding;

public class SeedDatabase : ISeedDatabase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IFCDbContext _dbContext;

    public SeedDatabase(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IFCDbContext dbContext)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _dbContext = dbContext;
    }
    private async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        await roleManager.CreateAsync(new IdentityRole(nameof(AppRole.SuperAdmin)));
        await roleManager.CreateAsync(new IdentityRole(nameof(AppRole.Admin)));
        await roleManager.CreateAsync(new IdentityRole(nameof(AppRole.Basic)));
    }
    private async Task SeedBasicUserAsync(UserManager<ApplicationUser> userManager)
    {
        //Seed Default User
        var defaultUser = new ApplicationUser
        {
            UserName = "basicuser",
            Email = "basicuser@gmail.com",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            FirstName = "Basic",
            LastName = "User",
            CNIC = "123456789101111"
        };
        if (userManager.Users.All(u => u.Id != defaultUser.Id))
        {
            var user = await userManager.FindByEmailAsync(defaultUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(defaultUser, "123");
                await userManager.AddToRoleAsync(defaultUser, nameof(AppRole.Basic));
            }
        }
    }
    private async Task SeedSuperAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        //Seed Default User
        var defaultUser = new ApplicationUser
        {
            UserName = "superadmin",
            Email = "superadmin@gmail.com",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            FirstName = "Super",
            LastName = "Admin",
            CNIC = "123456789101111"
        };
        if (userManager.Users.All(u => u.Id != defaultUser.Id))
        {
            var user = await userManager.FindByEmailAsync(defaultUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(defaultUser, "123");
                await userManager.AddToRoleAsync(defaultUser, nameof(AppRole.Basic));
                await userManager.AddToRoleAsync(defaultUser, nameof(AppRole.Admin));
                await userManager.AddToRoleAsync(defaultUser, nameof(AppRole.SuperAdmin));
            }
            await roleManager.AddPermissionClaimAsync("SuperAdmin", "Product");
        }
    }
    public async Task DatabaseSeederAsync()
    {
        //Roles Seeder
        await SeedRolesAsync(_roleManager);
        await SeedBasicUserAsync(_userManager);
        await SeedSuperAdminAsync(_userManager, _roleManager);

        // Database Table Seedings -- Insertion order matter -- Keep in Mind
        await InsertDistricts();
        await InsertCities();
        await InsertApprovalRequestType();
        await InsertSectorHeadQuarter();
        await InsertCoreHeadQuarter();
        await InsertLocation();
        await InsertOperationalBase();
        await InsertTerroristInvolvement();
        await InsertFunder();
        await InsertRelationType();
        await InsertInvolvement();
        await InsertAffiliate();
        await InsertApprovals();
        await InsertAddresses();
        await InsertTerroristFamilyDetail();
        await InsertTerroristFacilitatorsDetail();
        await InsertSocialMediaProfiles();
        await InsertSuspectFamilyDetail();
        await InsertOrganization();
        await InsertTerroristProfile();
        await InsertSuspectProfile();
        await InsertOrganizationFunder();
        await InsertWing();
        await InsertIncident();
        await InsertThreat();
    }
    #region Approval Request Type
    private async Task InsertApprovalRequestType()
    {
        var getApprovalRequestTypes = await _dbContext.ApprovalRequestTypes.ToListAsync();
        if (getApprovalRequestTypes == null || getApprovalRequestTypes.Count == 0)
        {
            await _dbContext.ApprovalRequestTypes.AddRangeAsync(GetApprovalRequestType());
            await _dbContext.SaveChangesAsync();
        }
    }

    private static List<ApprovalRequestType> GetApprovalRequestType()
    {
        //Seed Database
        return new Faker<ApprovalRequestType>()
            .RuleFor(o => o.RequestType, f => f.Random.Word())
            .Generate(10);
    }
    #endregion

    #region Approvals
    private async Task InsertApprovals()
    {
        var getApprovals = await _dbContext.Approvals.ToListAsync();
        if (getApprovals == null || getApprovals.Count == 0)
        {
            await _dbContext.Approvals.AddRangeAsync(GetApprovals());
            await _dbContext.SaveChangesAsync();
        }
    }
    private static List<Approval> GetApprovals()
    {
        // Seed Database
        return new Faker<Approval>()
            .RuleFor(o => o.InitiatedOn, f => f.Date.Between(DateTime.Now, DateTime.Now.AddYears(100)))
            .RuleFor(o => o.ApprovalRequestTypeId, f => f.Random.Int(1, 10))
            .RuleFor(o => o.ApprovalStatus, f => f.Random.Bool())
            .RuleFor(o => o.InitiatedOn, f => f.Date.Between(DateTime.Now.AddYears(-1300), DateTime.Now))
            .Generate(10);
    }
    #endregion

    #region Addresses
    private async Task InsertAddresses()
    {
        var getAddresses = await _dbContext.Addresses.ToListAsync();
        if (getAddresses == null || getAddresses.Count == 0)
        {
            await _dbContext.Addresses.AddRangeAsync(GetAddresses());
            await _dbContext.SaveChangesAsync();
        }
    }
    private static List<Address> GetAddresses()
    {
        // Seed Database
        return new Faker<Address>()
            .RuleFor(o => o.Streat, f => f.Person.Address.Street)
            .RuleFor(o => o.CityId, f => f.Random.Int(1, 10))
            .RuleFor(o => o.DistrictId, f => f.Random.Int(1, 10))
            .Generate(10);
    }
    #endregion

    #region Districts
    private async Task InsertDistricts()
    {
        var getDistricts = await _dbContext.Districts.ToListAsync();
        if (getDistricts == null || getDistricts.Count == 0)
        {
            await _dbContext.Districts.AddRangeAsync(GetDistricts());
            await _dbContext.SaveChangesAsync();
        }
    }
    private static List<District> GetDistricts()
    {
        // Seed Database
        return new Faker<District>()
            .RuleFor(o => o.Name, f => f.Person.Address.State)
            .Generate(10);
    }
    #endregion

    #region Cities
    private async Task InsertCities()
    {
        var getCities = await _dbContext.Cities.ToListAsync();
        if (getCities == null || getCities.Count == 0)
        {
            await _dbContext.Cities.AddRangeAsync(GetCities());
            await _dbContext.SaveChangesAsync();
        }
    }
    private static List<City> GetCities()
    {
        // Seed Database
        return new Faker<City>()
            .RuleFor(o => o.Name, f => f.Person.Address.City)
            .Generate(10);
    }
    #endregion

    #region Sector Head Quarter
    private async Task InsertSectorHeadQuarter()
    {
        var getSectorHeadQuarters = await _dbContext.SectorHeadQuarters.ToListAsync();
        if (getSectorHeadQuarters == null || getSectorHeadQuarters.Count == 0)
        {
            await _dbContext.SectorHeadQuarters.AddRangeAsync(GetSectorHeadQuarter());
            await _dbContext.SaveChangesAsync();
        }
    }
    private static List<SectorHeadQuarter> GetSectorHeadQuarter()
    {
        // Seed Database
        return new Faker<SectorHeadQuarter>()
            .RuleFor(o => o.Name, f => f.Lorem.Word())
            .RuleFor(o => o.Description, f => f.Lorem.Paragraph())
            .Generate(10);
    }
    #endregion
    #region Core Head Quarter
    private async Task InsertCoreHeadQuarter()
    {
        var getCoreHeadQuarters = await _dbContext.CoreHeadQuarters.ToListAsync();
        if (getCoreHeadQuarters == null || getCoreHeadQuarters.Count == 0)
        {
            await _dbContext.CoreHeadQuarters.AddRangeAsync(GetCoreHeadQuarter());
            await _dbContext.SaveChangesAsync();
        }
    }
    private static List<CoreHeadQuarter> GetCoreHeadQuarter()
    {
        // Seed Database
        return new Faker<CoreHeadQuarter>()
            .RuleFor(o => o.Name, f => f.Lorem.Word())
            .RuleFor(o => o.Description, f => f.Lorem.Paragraph())
            .RuleFor(o => o.DisplayName, f => f.Lorem.Word())
            .RuleFor(o => o.SectorHeadQuarterId, f => f.Random.Int(1, 10))
            .Generate(10);
    }
    #endregion
    #region Wings
    private async Task InsertWing()
    {
        var getWings = await _dbContext.Wings.ToListAsync();
        if (getWings == null || getWings.Count == 0)
        {
            await _dbContext.Wings.AddRangeAsync(GetWing());
            await _dbContext.SaveChangesAsync();
        }
    }
    private static List<Wing> GetWing()
    {
        // Seed Database
        return new Faker<Wing>()
            .RuleFor(o => o.Name, f => f.Lorem.Word())
            .RuleFor(o => o.Description, f => f.Lorem.Paragraph())
            .RuleFor(o => o.DisplayName, f => f.Lorem.Word())
            .RuleFor(o => o.IsSacaapplied, f => f.Random.Bool())
            .RuleFor(o => o.Sacatype, f => f.Random.Int(1, 10))
            .RuleFor(o => o.WingType, f => f.Random.Int(1, 10))
            .RuleFor(o => o.CoreHeadQuarterId, f => f.Random.Int(1, 10))
            .Generate(10);
    }
    #endregion

    #region Organizations
    private async Task InsertOrganization()
    {
        var getOrganizations = await _dbContext.Organizations.ToListAsync();
        if (getOrganizations == null || getOrganizations.Count == 0)
        {
            await _dbContext.Organizations.AddRangeAsync(GetOrganization());
            await _dbContext.SaveChangesAsync();
        }
    }
    private static List<Organization> GetOrganization()
    {
        // Seed Database
        return new Faker<Organization>()
            .RuleFor(o => o.Name, f => f.Lorem.Word())
            .RuleFor(o => o.TotalMembers, f => f.Random.Int())
            .RuleFor(o => o.YearFounded, f => f.Date.Between(DateTime.Now.AddYears(-1300), DateTime.Now))
            .RuleFor(o => o.ThreatLevel, f => f.Random.Byte(0, 5))
            .RuleFor(o => o.AffiliateId, f => f.Random.Int(1, 10))
            .RuleFor(o => o.OperationalBaseId, f => f.Random.Int(1, 10))
            .RuleFor(o => o.InvolvementId, f => f.Random.Int(1, 10))
            .RuleFor(o => o.SocialMediaProfileId, f => f.Random.Int(1, 10))
            .Generate(10);
    }
    #endregion

    #region Affiliates
    private async Task InsertAffiliate()
    {
        var getAffiliates = await _dbContext.Affiliates.ToListAsync();
        if (getAffiliates == null || getAffiliates.Count == 0)
        {
            await _dbContext.Affiliates.AddRangeAsync(GetAffiliate());
            await _dbContext.SaveChangesAsync();
        }
    }
    private static List<Affiliate> GetAffiliate()
    {
        // Seed Database
        return new Faker<Affiliate>()
            .RuleFor(o => o.LocalAffiliate, f => f.Lorem.Word())
            .RuleFor(o => o.ForeignAffiliate, f => f.Lorem.Word())
            .Generate(10);
    }
    #endregion

    #region Funders
    private async Task InsertFunder()
    {
        var getFunders = await _dbContext.Funders.ToListAsync();
        if (getFunders == null || getFunders.Count == 0)
        {
            await _dbContext.Funders.AddRangeAsync(GetFunder());
            await _dbContext.SaveChangesAsync();
        }
    }
    private static List<Funder> GetFunder()
    {
        // Seed Database
        return new Faker<Funder>()
            .RuleFor(o => o.Name, f => f.Person.FullName)
            .RuleFor(o => o.FundingSource, f => f.Lorem.Word())
            .Generate(10);
    }
    #endregion

    #region Incidents
    private async Task InsertIncident()
    {
        var getIncident = await _dbContext.Incidents.ToListAsync();
        if (getIncident == null || getIncident.Count == 0)
        {
            await _dbContext.Incidents.AddRangeAsync(GetIncident());
            await _dbContext.SaveChangesAsync();
        }
    }
    private static List<Incident> GetIncident()
    {
        // Seed Database
        return new Faker<Incident>()
            .RuleFor(o => o.IncidentDate, f => f.Date.Between(DateTime.Now.AddYears(-1300), DateTime.Now))
            .RuleFor(o => o.SuspectsProfileId, f => f.Random.Int(1, 10))
            .RuleFor(o => o.OrganizationId, f => f.Random.Int(1, 10))
            .RuleFor(o => o.WingId, f => f.Random.Int(1, 10))
            .RuleFor(o => o.LocationId, f => f.Random.Int(1, 10))
            .Generate(10);
    }
    #endregion

    #region Involvements
    private async Task InsertInvolvement()
    {
        var getInvolvements = await _dbContext.Involvements.ToListAsync();
        if (getInvolvements == null || getInvolvements.Count == 0)
        {
            await _dbContext.Involvements.AddRangeAsync(GetInvolvement());
            await _dbContext.SaveChangesAsync();
        }
    }
    private static List<Involvement> GetInvolvement()
    {
        // Seed Database
        return new Faker<Involvement>()
            .RuleFor(o => o.Name, f => f.Lorem.Word())
            .Generate(10);
    }
    #endregion

    #region Locations
    private async Task InsertLocation()
    {
        var getLocations = await _dbContext.Locations.ToListAsync();
        if (getLocations == null || getLocations.Count == 0)
        {
            await _dbContext.Locations.AddRangeAsync(GetLocation());
            await _dbContext.SaveChangesAsync();
        }
    }
    private static List<Location> GetLocation()
    {
        // Seed Database
        return new Faker<Location>()
            .RuleFor(o => o.Name, f => f.Lorem.Word())
            .RuleFor(o => o.Latitude, f => f.Random.Decimal())
            .RuleFor(o => o.Longitude, f => f.Random.Decimal())
            .Generate(10);

        //f.Date.Between(DateTime.Now.AddYears(-1300), DateTime.Now)
    }
    #endregion

    #region Operational Bases
    private async Task InsertOperationalBase()
    {
        var getOperationalBases = await _dbContext.OperationalBases.ToListAsync();
        if (getOperationalBases == null || getOperationalBases.Count == 0)
        {
            await _dbContext.OperationalBases.AddRangeAsync(GetOperationalBases());
            await _dbContext.SaveChangesAsync();
        }
    }
    private static List<OperationalBase> GetOperationalBases()
    {
        // Seed Database
        return new Faker<OperationalBase>()
            .RuleFor(o => o.Name, f => f.Lorem.Word())
            .Generate(10);
    }
    #endregion

    #region Organization Funders
    private async Task InsertOrganizationFunder()
    {
        var getOrganizationFunders = await _dbContext.OrganizationFunders.ToListAsync();
        if (getOrganizationFunders == null || getOrganizationFunders.Count == 0)
        {
            await _dbContext.OrganizationFunders.AddRangeAsync(GetOrganizationFunder());
            await _dbContext.SaveChangesAsync();
        }
    }
    private static List<OrganizationFunder> GetOrganizationFunder()
    {
        // Seed Database
        return new Faker<OrganizationFunder>()
            .RuleFor(o => o.FunderId, f => f.Random.Int(1, 10))
            .RuleFor(o => o.OrganizationId, f => f.Random.Int(1, 10))
            .Generate(10);
    }
    #endregion

    #region Relation Types
    private async Task InsertRelationType()
    {
        var getRelationTypes = await _dbContext.RelationTypes.ToListAsync();
        if (getRelationTypes == null || getRelationTypes.Count == 0)
        {
            await _dbContext.RelationTypes.AddRangeAsync(GetRelationType());
            await _dbContext.SaveChangesAsync();
        }
    }
    private static List<RelationType> GetRelationType()
    {
        // Seed Database
        return new Faker<RelationType>()
            .RuleFor(o => o.Name, f => f.Lorem.Word())
            .Generate(10);
    }
    #endregion

    #region Social Media Profiles
    private async Task InsertSocialMediaProfiles()
    {
        var getSocialMediaProfiles = await _dbContext.SocialMediaProfiles.ToListAsync();
        if (getSocialMediaProfiles == null || getSocialMediaProfiles.Count == 0)
        {
            await _dbContext.SocialMediaProfiles.AddRangeAsync(GetSocialMediaProfiles());
            await _dbContext.SaveChangesAsync();
        }
    }
    private static List<SocialMediaProfile> GetSocialMediaProfiles()
    {
        // Seed Database
        return new Faker<SocialMediaProfile>()
            .RuleFor(o => o.Name, f => f.Lorem.Word())
            .Generate(10);
    }
    #endregion

    #region Suspect Profiles
    private async Task InsertSuspectProfile()
    {
        var getSuspectProfiles = await _dbContext.SuspectProfiles.ToListAsync();
        if (getSuspectProfiles == null || getSuspectProfiles.Count == 0)
        {
            await _dbContext.SuspectProfiles.AddRangeAsync(GetSuspectProfiles());
            await _dbContext.SaveChangesAsync();
        }
    }
    private static List<SuspectProfile> GetSuspectProfiles()
    {
        // Seed Database
        return new Faker<SuspectProfile>()
            .RuleFor(o => o.FirstName, f => f.Person.FirstName)
            .RuleFor(o => o.LastName, f => f.Person.LastName)
            .RuleFor(o => o.FatherName, f => f.Person.FullName)
            .RuleFor(o => o.DateOfBirth, f => f.Date.Between(DateTime.Now.AddYears(-1300), DateTime.Now))
            .RuleFor(o => o.TribeOrCast, f => f.Lorem.Word())
            .RuleFor(o => o.Sect, f => f.Lorem.Word())
            .RuleFor(o => o.CNIC, f => f.Person.Random.Digits(13, 0, 9).ToString())
            .RuleFor(o => o.Passport, f => f.Person.Random.Digits(9, 0, 9).ToString())
            .RuleFor(o => o.MaritalStatus, f => f.Random.Bool())
            .RuleFor(o => o.GeneralRemarks, f => f.Lorem.Paragraph())
            .RuleFor(o => o.AddressId, f => f.Random.Int(1, 10))
            .RuleFor(o => o.OrganizationId, f => f.Random.Int(1, 10))
            .RuleFor(o => o.SuspectFamilyDetailsId, f => f.Random.Int(1, 10))
            .Generate(10);
    }
    #endregion

    #region Suspect Family Details
    private async Task InsertSuspectFamilyDetail()
    {
        var getSuspectFamilyDetails = await _dbContext.SuspectFamilyDetails.ToListAsync();
        if (getSuspectFamilyDetails == null || getSuspectFamilyDetails.Count == 0)
        {
            await _dbContext.SuspectFamilyDetails.AddRangeAsync(GetSuspectFamilyDetail());
            await _dbContext.SaveChangesAsync();
        }
    }
    private static List<SuspectFamilyDetail> GetSuspectFamilyDetail()
    {
        // Seed Database
        return new Faker<SuspectFamilyDetail>()
            .RuleFor(o => o.FirstName, f => f.Person.FirstName)
            .RuleFor(o => o.LastName, f => f.Person.LastName)
            .RuleFor(o => o.DateOfBirth, f => f.Date.Between(DateTime.Now.AddYears(-1300), DateTime.Now))
            .RuleFor(o => o.CNIC, f => f.Person.Random.Digits(13, 0, 9).ToString())
            .RuleFor(o => o.Passport, f => f.Random.Digits(9, 0, 9).ToString())
            .RuleFor(o => o.MaritalStatus, f => f.Random.Bool())
            .RuleFor(o => o.RelationTypeId, f => f.Random.Int(1, 10))
            .Generate(10);
    }
    #endregion

    #region Terrorist Facilitators Details
    private async Task InsertTerroristFacilitatorsDetail()
    {
        var getTerroristFacilitatorsDetails = await _dbContext.TerroristFacilitatorsDetails.ToListAsync();
        if (getTerroristFacilitatorsDetails == null || getTerroristFacilitatorsDetails.Count == 0)
        {
            await _dbContext.TerroristFacilitatorsDetails.AddRangeAsync(GetTerroristFacilitatorsDetail());
            await _dbContext.SaveChangesAsync();
        }
    }
    private static List<TerroristFacilitatorsDetail> GetTerroristFacilitatorsDetail()
    {
        // Seed Database
        return new Faker<TerroristFacilitatorsDetail>()
            .RuleFor(o => o.FirstName, f => f.Person.FirstName)
            .RuleFor(o => o.LastName, f => f.Person.LastName)
            .RuleFor(o => o.DateOfBirth, f => f.Date.Between(DateTime.Now.AddYears(-1300), DateTime.Now))
            .RuleFor(o => o.CNIC, f => f.Person.Random.Digits(13, 0, 9).ToString())
            .RuleFor(o => o.Passport, f => f.Random.Digits(9, 0, 9).ToString())
            .RuleFor(o => o.MaritalStatus, f => f.Random.Bool())
             .RuleFor(o => o.TribeOrCast, f => f.Lorem.Word())
            .RuleFor(o => o.Sect, f => f.Lorem.Word())
            .RuleFor(o => o.AddressId, f => f.Random.Int(1, 10))
            .RuleFor(o => o.RelationTypeId, f => f.Random.Int(1, 10))
            .Generate(10);
    }
    #endregion

    #region Terrorist Family Details
    private async Task InsertTerroristFamilyDetail()
    {
        var getTerroristFamilyDetails = await _dbContext.TerroristFamilyDetails.ToListAsync();
        if (getTerroristFamilyDetails == null || getTerroristFamilyDetails.Count == 0)
        {
            await _dbContext.TerroristFamilyDetails.AddRangeAsync(GetTerroristFamilyDetail());
            await _dbContext.SaveChangesAsync();
        }
    }
    private static List<TerroristFamilyDetail> GetTerroristFamilyDetail()
    {
        // Seed Database
        return new Faker<TerroristFamilyDetail>()
            .RuleFor(o => o.FirstName, f => f.Person.FirstName)
            .RuleFor(o => o.LastName, f => f.Person.LastName)
            .RuleFor(o => o.DateOfBirth, f => f.Date.Between(DateTime.Now.AddYears(-1300), DateTime.Now))
             .RuleFor(o => o.TribeOrCast, f => f.Lorem.Word())
            .RuleFor(o => o.Sect, f => f.Lorem.Word())
            .RuleFor(o => o.CNIC, f => f.Person.Random.Digits(13, 0, 9).ToString())
            .RuleFor(o => o.Passport, f => f.Random.Digits(9, 0, 9).ToString())
            .RuleFor(o => o.MaritalStatus, f => f.Random.Bool())
            .RuleFor(o => o.AddressId, f => f.Random.Int(1, 10))
            .RuleFor(o => o.RelationTypeId, f => f.Random.Int(1, 10))
            .Generate(10);
    }
    #endregion

    #region Terrorist Involvements
    private async Task InsertTerroristInvolvement()
    {
        var getTerroristInvolvements = await _dbContext.TerroristInvolvements.ToListAsync();
        if (getTerroristInvolvements == null || getTerroristInvolvements.Count == 0)
        {
            await _dbContext.TerroristInvolvements.AddRangeAsync(GetTerroristInvolvement());
            await _dbContext.SaveChangesAsync();
        }
    }
    private static List<TerroristInvolvement> GetTerroristInvolvement()
    {
        // Seed Database
        return new Faker<TerroristInvolvement>()
            .RuleFor(o => o.Involvement, f => f.Lorem.Word())
            .Generate(10);
    }
    #endregion

    #region Terrorist Profiles
    private async Task InsertTerroristProfile()
    {
        var getTerroristProfiles = await _dbContext.TerroristProfiles.ToListAsync();
        if (getTerroristProfiles == null || getTerroristProfiles.Count == 0)
        {
            await _dbContext.TerroristProfiles.AddRangeAsync(GetTerroristProfile());
            await _dbContext.SaveChangesAsync();
        }
    }
    private static List<TerroristProfile> GetTerroristProfile()
    {
        // Seed Database
        return new Faker<TerroristProfile>()
            .RuleFor(o => o.FirstName, f => f.Person.FirstName)
            .RuleFor(o => o.LastName, f => f.Person.LastName)
            .RuleFor(o => o.FatherName, f => f.Person.FullName)
            .RuleFor(o => o.NameAlias, f => f.Person.FullName)
            .RuleFor(o => o.DateOfBirth, f => f.Date.Between(DateTime.Now.AddYears(-1300), DateTime.Now))
            .RuleFor(o => o.TribeOrCast, f => f.Lorem.Word())
            .RuleFor(o => o.Sect, f => f.Lorem.Word())
            .RuleFor(o => o.CNIC, f => f.Person.Random.Digits(13, 0, 9).ToString())
            .RuleFor(o => o.Passport, f => f.Random.Digits(9, 0, 9).ToString())
            .RuleFor(o => o.MaritalStatus, f => f.Random.Bool())
            .RuleFor(o => o.IsFounder, f => f.Random.Bool())
            .RuleFor(o => o.GeneralRemarks, f => f.Lorem.Paragraph())
            .RuleFor(o => o.AddressId, f => f.Random.Int(1, 10))
            .RuleFor(o => o.OrganizationId, f => f.Random.Int(1, 10))
            .RuleFor(o => o.TerroristInvolvementId, f => f.Random.Int(1, 10))
            .RuleFor(o => o.TerroristFamilyDetailsId, f => f.Random.Int(1, 10))
            .RuleFor(o => o.TerroristFacilitatorsDetailsId, f => f.Random.Int(1, 10))
            //.RuleFor(o => o.SuspectFamilyDetailsId, f => f.Random.Int(1, 10))
            .Generate(10);
        //.RuleFor(o => o., f => f.Date.Between(DateTime.Now.AddYears(-1300), DateTime.Now))
    }
    #endregion

    #region Threats
    private async Task InsertThreat()
    {
        var getThreats = await _dbContext.Threats.ToListAsync();
        if (getThreats == null || getThreats.Count == 0)
        {
            await _dbContext.Threats.AddRangeAsync(GetThreat());
            await _dbContext.SaveChangesAsync();
        }
    }
    private static List<Threat> GetThreat()
    {
        // Seed Database
        return new Faker<Threat>()
            .RuleFor(o => o.ThreatDate, f => f.Date.Between(DateTime.Now.AddYears(-1300), DateTime.Now))
            .RuleFor(o => o.WingId, f => f.Random.Int(1, 10))
            .RuleFor(o => o.OrganizationId, f => f.Random.Int(1, 10))
            .RuleFor(o => o.ThreatLevel, f => f.Random.Byte(0, 5))
            .RuleFor(o => o.SuspectsProfileId, f => f.Random.Int(1, 10))
            .RuleFor(o => o.IncidentId, f => f.Random.Int(1, 10))
            .RuleFor(o => o.LocationId, f => f.Random.Int(1, 10))
            .Generate(10);
    }
    #endregion
}