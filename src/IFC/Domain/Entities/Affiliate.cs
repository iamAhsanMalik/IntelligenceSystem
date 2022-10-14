namespace IFC.Domain.Entities;

public class Affiliate
{
    public Affiliate()
    {
        Organizations = new HashSet<Organization>();
    }

    public long Id { get; set; }
    public string? LocalAffiliate { get; set; }
    public string? ForiegnAffiliate { get; set; }
    public bool? IsDeleted { get; set; }
    public bool? IsActive { get; set; }

    public virtual ICollection<Organization> Organizations { get; set; }
}