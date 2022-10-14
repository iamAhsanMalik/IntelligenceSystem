namespace IFC.Domain.Entities;

public class Funder
{
    public Funder()
    {
        OrganizationFunders = new HashSet<OrganizationFunder>();
    }

    public long Id { get; set; }
    public string? Name { get; set; }
    public string? FundingSource { get; set; }
    public bool? IsDeleted { get; set; }
    public bool? IsActive { get; set; }

    public virtual ICollection<OrganizationFunder> OrganizationFunders { get; set; }
}
