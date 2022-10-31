namespace IFC.Domain.Entities;

public class SuspectFamilyDetail
{
    public SuspectFamilyDetail()
    {
        SuspectProfiles = new HashSet<SuspectProfile>();
    }

    public long Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? FullName { get => $"{FirstName} {LastName}"; }
    public DateTime? DateOfBirth { get; set; }
    public string? CNIC { get; set; }
    public string? Passport { get; set; }
    public bool? MaritalStatus { get; set; }
    public bool? IsDeleted { get; set; }
    public bool? IsActive { get; set; }

    public long? RelationTypeId { get; set; }

    public virtual RelationType? RelationType { get; set; } = new RelationType();
    public virtual ICollection<SuspectProfile> SuspectProfiles { get; set; }
}
