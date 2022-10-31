namespace IFC.Infrastructure.Persistence;

public class IFCDbContext : IdentityDbContext<ApplicationUser>
{
    public IFCDbContext(DbContextOptions<IFCDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Apply Entities Configurations
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        // Identity Table Name Configuration
        modelBuilder.Entity<ApplicationUser>(b => b.ToTable("Users"));
        modelBuilder.Entity<IdentityUserClaim<string>>(b => b.ToTable("UserClaims"));
        modelBuilder.Entity<IdentityUserLogin<string>>(b => b.ToTable("UserLogins"));
        modelBuilder.Entity<IdentityUserToken<string>>(b => b.ToTable("UserTokens"));
        modelBuilder.Entity<IdentityRole>(b => b.ToTable("Roles"));
        modelBuilder.Entity<IdentityRoleClaim<string>>(b => b.ToTable("RoleClaims"));
        modelBuilder.Entity<IdentityUserRole<string>>(b => b.ToTable("UserRoles"));
    }

    public virtual DbSet<Address> Addresses { get; set; } = null!;
    public virtual DbSet<Affiliate> Affiliates { get; set; } = null!;
    public virtual DbSet<Approval> Approvals { get; set; } = null!;
    public virtual DbSet<ApprovalRequestType> ApprovalRequestTypes { get; set; } = null!;
    public virtual DbSet<City> Cities { get; set; } = null!;
    public virtual DbSet<CoreHeadQuarter> CoreHeadQuarters { get; set; } = null!;
    public virtual DbSet<District> Districts { get; set; } = null!;
    public virtual DbSet<Funder> Funders { get; set; } = null!;
    public virtual DbSet<Incident> Incidents { get; set; } = null!;
    public virtual DbSet<Involvement> Involvements { get; set; } = null!;
    public virtual DbSet<Location> Locations { get; set; } = null!;
    public virtual DbSet<OperationalBase> OperationalBases { get; set; } = null!;
    public virtual DbSet<Organization> Organizations { get; set; } = null!;
    public virtual DbSet<OrganizationFunder> OrganizationFunders { get; set; } = null!;
    public virtual DbSet<RelationType> RelationTypes { get; set; } = null!;
    public virtual DbSet<SectorHeadQuarter> SectorHeadQuarters { get; set; } = null!;
    public virtual DbSet<SocialMediaProfile> SocialMediaProfiles { get; set; } = null!;
    public virtual DbSet<SuspectFamilyDetail> SuspectFamilyDetails { get; set; } = null!;
    public virtual DbSet<SuspectProfile> SuspectProfiles { get; set; } = null!;
    public virtual DbSet<TerroristFacilitatorsDetail> TerroristFacilitatorsDetails { get; set; } = null!;
    public virtual DbSet<TerroristFamilyDetail> TerroristFamilyDetails { get; set; } = null!;
    public virtual DbSet<TerroristInvolvement> TerroristInvolvements { get; set; } = null!;
    public virtual DbSet<TerroristProfile> TerroristProfiles { get; set; } = null!;
    public virtual DbSet<Threat> Threats { get; set; } = null!;
    public virtual DbSet<Wing> Wings { get; set; } = null!;

}

// dotnet ef dbcontext scaffold Name=ConnectionStrings:DefaultConnection Microsoft.EntityFrameworkCore.SqlServer -c IFCDbContext -p src/IFC -o Infrastructure/Persistence/Models
// dotnet ef dbcontext scaffold Name=ConnectionStrings:TestConnection Microsoft.EntityFrameworkCore.SqlServer -c IFCDbContext -p src/IFC -o Infrastructure/Persistence/TestModels