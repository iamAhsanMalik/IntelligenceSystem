namespace IFC.Application.DTOs.SuspectProfile;

public class SuspectProfileDTO
{
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

  

    public virtual string? Address { get; set; }
    public virtual string? Orgnization { get; set; }
    public virtual string? SuspectFamilyDetails { get; set; }
}
