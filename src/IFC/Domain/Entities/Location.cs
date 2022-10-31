namespace IFC.Domain.Entities;

public class Location
{
    public Location()
    {
        Incidents = new HashSet<Incident>();
        Threats = new HashSet<Threat>();
    }

    public long Id { get; set; }
    public string? Name { get; set; }
    public decimal? Latitude { get; set; }
    public decimal? Longitude { get; set; }
    public bool? IsDeleted { get; set; }
    public bool? IsActive { get; set; }

    public virtual ICollection<Incident> Incidents { get; set; }
    public virtual ICollection<Threat> Threats { get; set; }
}
