namespace IFC.Domain.Entities;

public class Organization
{
    public Organization()
    {
        Incidents = new HashSet<Incident>();
        OrganizationFunders = new HashSet<OrganizationFunder>();
        SuspectProfiles = new HashSet<SuspectProfile>();
        TerroristProfiles = new HashSet<TerroristProfile>();
        Threats = new HashSet<Threat>();
    }

    public long Id { get; set; }
    public string? Name { get; set; }
    public long? TotalMembers { get; set; }
    public DateTime? YearFounded { get; set; }
    public byte? ThreatLevel { get; set; }
    public string? Details { get; set; }
    public bool? IsDeleted { get; set; }
    public bool? IsActive { get; set; }

    public long? AffiliateId { get; set; }
    public long? OperationalBaseId { get; set; }
    public long? InvolvementId { get; set; }
    public long? SocialMediaProfileId { get; set; }

    public virtual Affiliate? Affiliate { get; set; }
    public virtual Involvement? Involvement { get; set; }
    public virtual OperationalBase? OperationalBase { get; set; }
    public virtual SocialMediaProfile? SocialMediaProfile { get; set; }
    public virtual ICollection<Incident> Incidents { get; set; }
    public virtual ICollection<OrganizationFunder> OrganizationFunders { get; set; }
    public virtual ICollection<SuspectProfile> SuspectProfiles { get; set; }
    public virtual ICollection<TerroristProfile> TerroristProfiles { get; set; }
    public virtual ICollection<Threat> Threats { get; set; }
}
