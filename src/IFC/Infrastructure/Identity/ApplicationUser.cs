namespace IFC.Infrastructure.Identity;

public class ApplicationUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? CNIC { get; set; }
    public string? ProfileImage { get; set; }
    public bool? IsDelete { get; set; }
    public bool? IsActive { get; set; }
}