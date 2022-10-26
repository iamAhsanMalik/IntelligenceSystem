using IFC.Application.Contracts.Identity;
using MapsterMapper;

namespace IFC.Infrastructure.Identity.Services;

internal sealed class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IMapper _mapper;

    public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IMapper mapper)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _mapper = mapper;
    }

    #region Login
    public async Task LoginAsync(ApplicationUser user, bool isPersistence = false) => await _signInManager.SignInAsync(user, isPersistent: isPersistence);
    public async Task<Microsoft.AspNetCore.Identity.SignInResult?> PasswordLoginAsync(LoginDTO model, bool lockoutUserOnFailure = false) =>
        !string.IsNullOrEmpty(model.Email) && !string.IsNullOrEmpty(model.Password) ? await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: lockoutUserOnFailure) : default;

    #endregion

    #region Register
    public async Task<IdentityResult?> RegisterAsync(ApplicationUser user) => await _userManager.CreateAsync(user);
    public async Task<IdentityResult?> RegisterWithPasswordAsync(RegisterDTO model) => await _userManager.CreateAsync(_mapper.Map<ApplicationUser>(model), model.Password);

    #endregion

    #region Logout
    public async Task LogoutAsync() => await _signInManager.SignOutAsync();
    #endregion

    #region Password Reset Token Generator
    public async Task<string> PasswordResetTokenGeneratorAsync(ApplicationUser user) => WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(await _userManager.GeneratePasswordResetTokenAsync(user)));
    public async Task<string> EmailConfirmationTokenGeneratorAsync(ApplicationUser user) => WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(await _userManager.GenerateEmailConfirmationTokenAsync(user)));
    public async Task<bool> UserTokenVerificationAsync(ApplicationUser applicationUser, string token)
    {
        return await _userManager.VerifyUserTokenAsync(applicationUser, _userManager.Options.Tokens.PasswordResetTokenProvider, "ResetPassword", token);
    }
    public async Task<IdentityResult?> PasswordResetAsync(ApplicationUser user, string code, string newPassword) => user != null && !string.IsNullOrEmpty(code) && !string.IsNullOrEmpty(newPassword) ? await _userManager.ResetPasswordAsync(user, code, newPassword) : default;
    public async Task<IdentityResult?> EmailConfirmationAsync(string userId, string code) => !string.IsNullOrEmpty(userId) || !string.IsNullOrEmpty(code) ? await _userManager.ConfirmEmailAsync(await _userManager.FindByIdAsync(userId), code) : default;
    #endregion
}