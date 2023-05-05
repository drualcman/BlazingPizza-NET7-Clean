namespace Membership.UserManager.AspNetIdentity;
internal class UserManagerService : IUserManagerService
{
    readonly UserManager<User> UserManager;

    public UserManagerService(UserManager<User> userManager) => UserManager = userManager;

    public async Task<List<string>> RegisterAsync(UserForRegistrationDto userData) 
    {
        User user = new User
        {
            UserName = userData.Email,
            FirstName = userData.FirstName,
            LastName = userData.LastName,
            Email = userData.Email
        };
        IdentityResult result = await UserManager.CreateAsync(user, userData.Password);
        List<string> errors = null;
        if (!result.Succeeded)
        {
            errors = result.Errors.Select(e=> e.Description).ToList();
        }
        return errors;
    }
}
