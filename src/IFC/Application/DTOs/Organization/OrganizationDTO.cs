namespace IFC.Application.DTOs.Organization;

public class OrganizationDTO
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public long? TotalMembers { get; set; }
    public DateTime? YearFounded { get; set; }
    public byte? ThreatLevel { get; set; }
    public string? Details { get; set; }
    public bool? IsDeleted { get; set; }
    public bool? IsActive { get; set; }

 

    public virtual string? Affiliate { get; set; }
    public virtual string? Involvement { get; set; }
    public virtual string? OperationalBase { get; set; }
    public virtual string? SocialMediaProfile { get; set; }
}
