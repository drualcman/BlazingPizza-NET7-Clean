namespace Membership.UserManager.AspNetIdentity;
internal class UserManagerContext : IdentityUserContext<User>
{
    readonly AspNetIdentityOptions Options;
    public UserManagerContext(IOptions<AspNetIdentityOptions> options)
    {             
        Options = options.Value;

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
    {
        optionsBuilder.UseSqlServer(Options.ConnectionString);
        base.OnConfiguring(optionsBuilder);
    }
}
