namespace IFC.Application.DTOs.OrganizationFunder;

public class OrganizationFunderDTO
{
    public long Id { get; set; }

    public bool? IsDeleted { get; set; }
    public bool? IsActive { get; set; }

    public string? Funder { get; set; }
    public string? Organization { get; set; }
}
