namespace IFC.Domain.Entities;

public class RelationType
{
    public RelationType()
    {
        SuspectFamilyDetails = new HashSet<SuspectFamilyDetail>();
        TerroristFacilitatorsDetails = new HashSet<TerroristFacilitatorsDetail>();
        TerroristFamilyDetails = new HashSet<TerroristFamilyDetail>();
    }

    public long Id { get; set; }
    public string? Name { get; set; }
    public bool? IsDeleted { get; set; }
    public bool? IsActive { get; set; }
    public virtual ICollection<SuspectFamilyDetail> SuspectFamilyDetails { get; set; }
    public virtual ICollection<TerroristFacilitatorsDetail> TerroristFacilitatorsDetails { get; set; }
    public virtual ICollection<TerroristFamilyDetail> TerroristFamilyDetails { get; set; }
}
