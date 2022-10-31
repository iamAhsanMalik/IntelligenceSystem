namespace IFC.Domain.Entities;

public class TerroristInvolvement
{
    public TerroristInvolvement()
    {
        TerroristProfiles = new HashSet<TerroristProfile>();
    }

    public long Id { get; set; }
    public string? Involvement { get; set; }
    public bool? IsDeleted { get; set; }
    public bool? IsActive { get; set; }

    public virtual ICollection<TerroristProfile> TerroristProfiles { get; set; }
}
