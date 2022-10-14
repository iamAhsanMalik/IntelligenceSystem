namespace IFC.Domain.Entities;

public class Threat
{
    public long Id { get; set; }
    public DateTime? ThreatDate { get; set; }
    public byte? ThreatLevel { get; set; }
    public bool? IsDeleted { get; set; }
    public bool? IsActive { get; set; }
    public long? WingId { get; set; }
    public long? OrganizationId { get; set; }
    public long? SuspectsProfileId { get; set; }
    public long? IncidentId { get; set; }
    public long? LocationId { get; set; }
    public virtual Incident? Incident { get; set; }
    public virtual Location? Location { get; set; }
    public virtual Organization? Organization { get; set; }
    public virtual SuspectProfile? SuspectsProfile { get; set; }
    public virtual Wing? Wing { get; set; }
}
