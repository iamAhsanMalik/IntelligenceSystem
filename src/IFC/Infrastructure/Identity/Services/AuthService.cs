using IFC.Application.DTOs;
using IFC.Infrastructure.Identity.Models;
using MapsterMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace IFC.Infrastructure.Identity.Services;

internal interface IAuthService
{
    Task LoginAsync(ApplicationUser user, bool isPersistence = false);
    Task LogoutAsync();
    Task<Microsoft.AspNetCore.Identity.SignInResult?> PasswordLoginAsync(LoginDTO model, bool lockoutUserOnFailure = false);
    Task<string> PasswordResetTokenGeneratorAsync(ApplicationUser user);
    Task<IdentityResult?> RegisterAsync(ApplicationUser user);
    Task<IdentityResult?> RegisterWithPasswordAsync(RegisterDTO model);
}

internal class AuthService : IAuthService
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
    #endregion
}