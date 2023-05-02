namespace Membership.Entities;
public interface IUserService
{
    bool IsAuthenticated { get; }
    string UserId { get; }
    string FullName { get; }
    void CheckIfIsAuthorizedGuard();
}
