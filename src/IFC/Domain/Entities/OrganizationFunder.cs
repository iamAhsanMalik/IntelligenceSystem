namespace IFC.Domain.Entities;

public class OrganizationFunder
{
    public long Id { get; set; }
    public long? FunderId { get; set; }
    public long? OrganizationId { get; set; }
    public bool? IsDeleted { get; set; }
    public bool? IsActive { get; set; }

    public virtual Funder? Funder { get; set; }
    public virtual Organization? Organization { get; set; }
}
