using Microsoft.AspNetCore.Identity;

namespace IFC.Infrastructure.Identity.Models;

public class ApplicationUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? CNIC { get; set; }
    public string? ProfileImage { get; set; }
    public bool IsActive { get; set; }
    // public long Desi { get; set; }
}