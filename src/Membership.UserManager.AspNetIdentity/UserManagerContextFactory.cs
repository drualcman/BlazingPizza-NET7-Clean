namespace Membership.UserManager.AspNetIdentity;
/// <summary>
/// add-migration InitialCreate -s Membership.UserManager.AspNetIdentity -p Membership.UserManager.AspNetIdentity
/// update-database -s Membership.UserManager.AspNetIdentity -p Membership.UserManager.AspNetIdentity
/// </summary>
internal class UserManagerContextFactory : IDesignTimeDbContextFactory<UserManagerContext>
{
    public UserManagerContext CreateDbContext(string[] args) =>
         new UserManagerContext(Options.Create(new AspNetIdentityOptions
         {
             ConnectionString = "Server=(localdb)\\mssqllocaldb;database=MembershipDBUserCS"
         }));
}
