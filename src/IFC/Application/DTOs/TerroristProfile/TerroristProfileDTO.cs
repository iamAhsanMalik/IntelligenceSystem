namespace IFC.Application.DTOs.TerroristProfile;

public class TerroristProfileDTO
{
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
    public string? Address { get; set; }
    public string? Organization { get; set; }
    public string? TerroristFacilitatorsDetails { get; set; }
    public string? TerroristFamilyDetails { get; set; }
    public string? TerroristInvolvement { get; set; }
}
