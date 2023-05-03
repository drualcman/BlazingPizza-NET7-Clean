namespace Membership.UserService;
internal class UserService : IUserService
{
    readonly HttpContext Context;
    public UserService(IHttpContextAccessor httpContextAccesor)
    {
        Context = httpContextAccesor.HttpContext;   
    }

    public bool IsAuthenticated => 
        Context.User?.Identity?.IsAuthenticated ?? false;

    public string UserId =>
        Context.User.Identity?.Name;

    public string FullName =>
        Context.User.Claims
        .Where(c => c.Type == "FullName")
        .Select(c => c.Value)
        .FirstOrDefault();
}
