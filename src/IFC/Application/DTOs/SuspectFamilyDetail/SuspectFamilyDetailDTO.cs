namespace IFC.Application.DTOs.SuspectFamilyDetail;

public class SuspectFamilyDetailDTO
{
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



    public string? RelationType { get; set; }
}
