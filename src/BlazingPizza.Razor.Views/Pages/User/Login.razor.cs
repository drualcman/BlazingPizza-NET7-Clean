namespace BlazingPizza.Razor.Views.Pages.User;
public partial class Login
{   
    [Inject] NavigationManager NavigationManager { get; set; }

    void OnLogin(UserTokensDto user)
    {
        Console.WriteLine($"Session Iniciada: {user.Access_Token} {user.Refresh_Token}");
        NavigationManager.NavigateTo("");
    }
}
