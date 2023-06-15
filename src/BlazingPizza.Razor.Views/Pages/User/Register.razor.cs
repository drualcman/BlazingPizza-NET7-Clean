namespace BlazingPizza.Razor.Views.Pages.User;
public partial class Register
{
    [Inject] NavigationManager NavigationManager { get; set; }

    void OnRegister(LocalUserForRegistrationDto user)
    {
        Console.WriteLine($"Usuario registrado: {user.FirstName} {user.LastName}");
        NavigationManager.NavigateTo("user/login");
    }

}
