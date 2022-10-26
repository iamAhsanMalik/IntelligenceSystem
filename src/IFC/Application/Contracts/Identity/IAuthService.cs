using IFC.Infrastructure.Identity;

namespace IFC.Application.Contracts.Identity;

public interface IAuthService
{
    Task<IdentityResult?> EmailConfirmationAsync(string userId, string code);
    Task<string> EmailConfirmationTokenGeneratorAsync(ApplicationUser user);
    Task LoginAsync(ApplicationUser user, bool isPersistence = false);
    Task LogoutAsync();
    Task<Microsoft.AspNetCore.Identity.SignInResult?> PasswordLoginAsync(LoginDTO model, bool lockoutUserOnFailure = false);
    Task<IdentityResult?> PasswordResetAsync(ApplicationUser user, string code, string newPassword);
    Task<string> PasswordResetTokenGeneratorAsync(ApplicationUser user);
    Task<IdentityResult?> RegisterAsync(ApplicationUser user);
    Task<IdentityResult?> RegisterWithPasswordAsync(RegisterDTO model);
    Task<bool> UserTokenVerificationAsync(ApplicationUser applicationUser, string token);
}