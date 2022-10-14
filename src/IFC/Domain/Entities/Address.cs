namespace IFC.Domain.Entities;

public class Address
{
    public Address()
    {
        SuspectProfiles = new HashSet<SuspectProfile>();
        TerroristFacilitatorsDetails = new HashSet<TerroristFacilitatorsDetail>();
        TerroristFamilyDetails = new HashSet<TerroristFamilyDetail>();
        TerroristProfiles = new HashSet<TerroristProfile>();
    }

    public long Id { get; set; }
    public string? Streat { get; set; }
    public bool? IsDeleted { get; set; }
    public bool? IsActive { get; set; }
    public long? CityId { get; set; }
    public long? DistrictId { get; set; }

    public virtual City? City { get; set; }
    public virtual District? District { get; set; }
    public virtual ICollection<SuspectProfile> SuspectProfiles { get; set; }
    public virtual ICollection<TerroristFacilitatorsDetail> TerroristFacilitatorsDetails { get; set; }
    public virtual ICollection<TerroristFamilyDetail> TerroristFamilyDetails { get; set; }
    public virtual ICollection<TerroristProfile> TerroristProfiles { get; set; }
}
