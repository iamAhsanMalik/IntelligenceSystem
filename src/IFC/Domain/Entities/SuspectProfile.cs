namespace IFC.Domain.Entities;
public class SuspectProfile
{
    public SuspectProfile()
    {
        Incidents = new HashSet<Incident>();
        Threats = new HashSet<Threat>();
    }

    public long Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? FullName { get => $"{FirstName} {LastName}"; }
    public string? FatherName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? TribeOrCast { get; set; }
    public string? Sect { get; set; }
    public string? CNIC { get; set; }
    public string? Passport { get; set; }
    public bool? MaritalStatus { get; set; }
    public string? GeneralRemarks { get; set; }
    public bool? IsDeleted { get; set; }
    public bool? IsActive { get; set; }

    public long? AddressId { get; set; }
    public long? OrganizationId { get; set; }
    public long? SuspectFamilyDetailsId { get; set; }

    public virtual Address? Address { get; set; } = new Address();
    public virtual Organization? Organization { get; set; } = new Organization();
    public virtual SuspectFamilyDetail? SuspectFamilyDetails { get; set; } = new SuspectFamilyDetail();
    public virtual ICollection<Incident> Incidents { get; set; }
    public virtual ICollection<Threat> Threats { get; set; }
}
