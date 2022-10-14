namespace IFC.Domain.Entities;

public class Wing
{
    public Wing()
    {
        Incidents = new HashSet<Incident>();
        Threats = new HashSet<Threat>();
    }

    public long Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool? IsSacaapplied { get; set; }
    public int? Sacatype { get; set; }
    public int? WingType { get; set; }
    public string? DisplayName { get; set; }
    public bool? IsActive { get; set; }
    public bool? IsDeleted { get; set; }
    public long? CoreHeadQuarterId { get; set; }
    public virtual CoreHeadQuarter? CoreHeadQuarter { get; set; }
    public virtual ICollection<Incident> Incidents { get; set; }
    public virtual ICollection<Threat> Threats { get; set; }
}
