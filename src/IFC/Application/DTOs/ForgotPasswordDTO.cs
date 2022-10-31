namespace IFC.Application.DTOs;

public class ForgotPasswordDTO
{
    [Required, EmailAddress]
    public string? Email { get; set; }
    public string? UserName { get; set; }
}
