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

    public virtual Location? Location { get; set; }
    public virtual Organization? Organization { get; set; }
    public virtual SuspectProfile? SuspectsProfile { get; set; }
    public virtual Wing? Wing { get; set; }
    public virtual ICollection<Threat> Threats { get; set; }
}
