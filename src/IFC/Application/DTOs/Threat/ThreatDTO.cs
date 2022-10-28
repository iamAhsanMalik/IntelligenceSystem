namespace IFC.Application.DTOs.Threat;

public class ThreatDTO
{
    public long Id { get; set; }
    public DateTime? ThreatDate { get; set; }
    public byte? ThreatLevel { get; set; }
    public bool? IsDeleted { get; set; }
    public bool? IsActive { get; set; }
    public string? Wing { get; set; }
    public string? Organization { get; set; }
    public string? SuspectsProfile { get; set; }
    public string? Incident { get; set; }
    public string? Location { get; set; }
    public int? TotalRecored { get; set; }
}
