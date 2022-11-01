namespace IFC.Domain.MODELS;

public class ThreatViewModel
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
   public string? WingName       { get; set; }   
   public string? OrganizationName { get; set; }
    public string?  SuspectProfiles { get; set; }
    public string? IncidentDate { get; set; }
    public string? LocationName { get; set; } 
}
