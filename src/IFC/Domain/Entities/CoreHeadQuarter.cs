namespace IFC.Domain.Entities;

public class CoreHeadQuarter
{
    public CoreHeadQuarter()
    {
        Wings = new HashSet<Wing>();
    }

    public long Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool? IsActive { get; set; }
    public string? DisplayName { get; set; }
    public long? SectorHeadQuarterId { get; set; }
    public bool? IsDeleted { get; set; }
    public virtual SectorHeadQuarter? SectorHeadQuarter { get; set; } = new SectorHeadQuarter();
    public virtual ICollection<Wing> Wings { get; set; }
}
