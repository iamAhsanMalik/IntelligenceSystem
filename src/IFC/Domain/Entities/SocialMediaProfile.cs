namespace IFC.Domain.Entities;

public class SocialMediaProfile
{
    public SocialMediaProfile()
    {
        Organizations = new HashSet<Organization>();
    }

    public long Id { get; set; }
    public string? Name { get; set; }
    public bool? IsDeleted { get; set; }
    public bool? IsActive { get; set; }

    public virtual ICollection<Organization> Organizations { get; set; }
}
