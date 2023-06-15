namespace Membership.Blazor.UI.Components;
public partial class RegisterComponent
{
    [Inject] IUserWebApiGateway Gateway { get; set; }
    [Parameter] public EventCallback<LocalUserForRegistrationDto> OnRegister{ get; set; }

    UserToRegister User = new();

    async Task Register()
    {
        LocalUserForRegistrationDto newUser = new(User.UserName, User.Password, User.FirstName, User.LastName);
        await Gateway.RegisterUserAsync(newUser);
        if(OnRegister.HasDelegate)
            await OnRegister.InvokeAsync(newUser);
    }
}
