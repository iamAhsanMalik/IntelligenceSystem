namespace IFC.Application.DTOs.CoreHeadQuarter;

public class CoreHeadQuarterDTO
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool? IsActive { get; set; }
    public string? DisplayName { get; set; }

    public bool? IsDeleted { get; set; }
    public string? SectorHeadQuarter { get; set; }
}
