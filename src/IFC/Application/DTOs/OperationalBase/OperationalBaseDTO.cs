namespace IFC.Application.DTOs.OperationalBase;

public class OperationalBaseDTO
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public bool? IsDeleted { get; set; }
    public bool? IsActive { get; set; }
}
