namespace IFC.Domain.Entities;

public class TerroristProfile
{
    public TerroristProfile()
    {
        Organizations = new HashSet<Organization>();
    }

    public long Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? FullName { get => $"{FirstName} {LastName}"; }
    public string? NameAlias { get; set; }
    public string? FatherName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? TribeOrCast { get; set; }
    public string? Sect { get; set; }
    public string? CNIC { get; set; }
    public string? Passport { get; set; }
    public bool? MaritalStatus { get; set; }
    public bool? IsFounder { get; set; }
    public string? GeneralRemarks { get; set; }
    public bool? IsDeleted { get; set; }
    public bool? IsActive { get; set; }

    public long? AddressId { get; set; }
    public long? OrganizationId { get; set; }
    public long? TerroristInvolvementId { get; set; }
    public long? TerroristFamilyDetailsId { get; set; }
    public long? TerroristFacilitatorsDetailsId { get; set; }

    public virtual Address? Address { get; set; }
    public virtual Organization? Organization { get; set; }
    public virtual TerroristFacilitatorsDetail? TerroristFacilitatorsDetails { get; set; }
    public virtual TerroristFamilyDetail? TerroristFamilyDetails { get; set; }
    public virtual TerroristInvolvement? TerroristInvolvement { get; set; }
    public virtual ICollection<Organization> Organizations { get; set; }
}
