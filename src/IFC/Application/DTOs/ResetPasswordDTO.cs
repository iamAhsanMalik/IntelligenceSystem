namespace IFC.Application.DTOs;

public class ResetPasswordDTO
{
    [Required, EmailAddress]
    public string? Email { get; set; }

    [Required, DataType(DataType.Password), StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
    public string? Password { get; set; }

    [DataType(DataType.Password), Display(Name = "Confirm password"), Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string? ConfirmPassword { get; set; }

    public string? PasswordResetToken { get; set; }
}
