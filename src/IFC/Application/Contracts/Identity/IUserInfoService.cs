namespace IFC.Application.Contracts.Identity;

public interface IUserInfoService
{
    Task<ApplicationUser> FindUserByEmailAsync(string userEmail);
    Task<ApplicationUser> FindUserByIdAsync(string userId);
    Task<string> FindUserFullNameAsync(string userId);
    Task<ApplicationUser?> GetCurrentLoginUserAsync();
    Task<string> GetCurrentLoginUserFullNameAsync();
    Task<string> GetCurrentLoginUserIdAsync();
    Task<IList<string>> GetCurrentLoginUserRolesListAsync();
    Task<string> GetCurrentLoginUserUserNameAsync();
    Task<string> GetUserEmailAsync(ApplicationUser user);
    Task<string> GetUserPhoneNumberAsync(ApplicationUser user);
    Task<bool> IsUserEmailConfirmedAsync(ApplicationUser user);
}