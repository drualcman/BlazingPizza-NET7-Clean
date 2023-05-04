namespace Membership.UserService;
internal class UserService : IUserService
{
    readonly IHttpContextAccessor ContextAccessor;
    public UserService(IHttpContextAccessor httpContextAccesor)
    {
        ContextAccessor = httpContextAccesor;   
    }

    public bool IsAuthenticated => 
        ContextAccessor.HttpContext.User?.Identity?.IsAuthenticated ?? false;

    public string UserId =>
        ContextAccessor.HttpContext.User.Identity?.Name;

    public string FullName =>
        ContextAccessor.HttpContext.User.Claims
        .Where(c => c.Type == "FullName")
        .Select(c => c.Value)
        .FirstOrDefault();
}
