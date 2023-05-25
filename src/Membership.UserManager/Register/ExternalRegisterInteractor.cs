namespace Membership.UserManager.Register;
internal class ExternalRegisterInteractor : IExternalRegisterInputPort
{
    readonly IUserManagerService UserManagerService;

    public ExternalRegisterInteractor(IUserManagerService userManagerService) => UserManagerService = userManagerService;

    public async Task RegisterAsync(ExternalUserForRegistrationDto userData)
    {
        await UserManagerService.ThrowIfUnableToResisterAsync(new UserForRegistrationDto
        {
            UserName = $"{userData.Provider}-{userData.USerID}",
            Email = userData.Email,
            FirstName = userData.FirstName,
            LastName = userData.LastName,
            Password = GetRandomPassword()
        });
    }

    string GetRandomPassword()
    {
        byte[] passwordBytes = new byte[20];
        passwordBytes[0] = GetRandomByteFromRange(65, 91);
        passwordBytes[1] = GetRandomByteFromRange(97, 123);
        passwordBytes[2] = GetRandomByteFromRange(33, 48);
        passwordBytes[3] = GetRandomByteFromRange(48, 58);

        for(int i = 4; i < 20; i++)
            passwordBytes[i] = GetRandomByteFromRange(33, 127);

        return Encoding.UTF8.GetString(passwordBytes);
    }

    byte GetRandomByteFromRange(int inclusive, int exclusive) =>
        (byte)new Random().Next(inclusive, exclusive);
}
