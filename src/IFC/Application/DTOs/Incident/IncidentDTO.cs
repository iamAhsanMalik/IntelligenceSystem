namespace IFC.Application.DTOs.Incident;

public class IncidentDTO
{
    public long Id { get; set; }
    public DateTime? IncidentDate { get; set; }
    public bool? IsDeleted { get; set; }
    public bool? IsActive { get; set; }


    public string? Location { get; set; }
    public string? Organization { get; set; }
    public string? SuspectsProfile { get; set; }
    public string? Wing { get; set; }
}
