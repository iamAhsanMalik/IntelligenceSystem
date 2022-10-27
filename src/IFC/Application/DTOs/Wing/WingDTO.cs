namespace IFC.Application.DTOs.Wing;

public class WingDTO
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool? IsSacaapplied { get; set; }
    public int? Sacatype { get; set; }
    public int? WingType { get; set; }
    public string? DisplayName { get; set; }
    public bool? IsActive { get; set; }
    public bool? IsDeleted { get; set; }

    public virtual string? CoreHeadQuarter { get; set; }
}
