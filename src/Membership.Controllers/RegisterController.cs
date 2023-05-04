namespace Membership.Controllers;
public class RegisterController : IRegisterController
{
    readonly IRegisterInputPort InputPort;

    public RegisterController(IRegisterInputPort inputPort) => InputPort = inputPort;

    public Task RegisterAsync(UserForRegistrationDto userData) => 
        InputPort.RegisterAsync(userData);
}
