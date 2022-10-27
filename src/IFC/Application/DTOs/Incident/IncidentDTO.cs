namespace IFC.Application.DTOs.Incident;

public class IncidentDTO
{
    public long Id { get; set; }
    public DateTime? IncidentDate { get; set; }
    public bool? IsDeleted { get; set; }
    public bool? IsActive { get; set; }


    public virtual string? Location { get; set; }
    public virtual string? Organization { get; set; }
    public virtual string? SuspectsProfile { get; set; }
    public virtual string? Wing { get; set; }
}
