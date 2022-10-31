namespace IFC.Domain.Entities;

public class Incident
{
    public Incident()
    {
        Threats = new HashSet<Threat>();
    }

    public long Id { get; set; }
    public DateTime? IncidentDate { get; set; }
    public bool? IsDeleted { get; set; }
    public bool? IsActive { get; set; }

    public long? SuspectsProfileId { get; set; }
    public long? OrganizationId { get; set; }
    public long? WingId { get; set; }
    public long? LocationId { get; set; }

    public virtual Location? Location { get; set; } = new Location();
    public virtual Organization? Organization { get; set; } = new Organization();
    public virtual SuspectProfile? SuspectsProfile { get; set; } = new SuspectProfile();
    public virtual Wing? Wing { get; set; } = new Wing();
    public virtual ICollection<Threat> Threats { get; set; }
}
