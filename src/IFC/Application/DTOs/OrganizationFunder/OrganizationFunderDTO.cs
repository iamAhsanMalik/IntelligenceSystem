namespace IFC.Application.DTOs.OrganizationFunder;

public class OrganizationFunderDTO
{
    public long Id { get; set; }
   
    public bool? IsDeleted { get; set; }
    public bool? IsActive { get; set; }

    public virtual String? Funder { get; set; }
    public virtual string? Organization { get; set; }
}
