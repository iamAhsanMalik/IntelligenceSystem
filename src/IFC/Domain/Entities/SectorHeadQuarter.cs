namespace IFC.Domain.Entities;

public class SectorHeadQuarter
{
    public SectorHeadQuarter()
    {
        CoreHeadQuarters = new HashSet<CoreHeadQuarter>();
    }

    public long Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool? IsActive { get; set; }
    public bool? IsDeleted { get; set; }

    public virtual ICollection<CoreHeadQuarter> CoreHeadQuarters { get; set; }
}
