﻿namespace Membership.UserService;
internal class UserServiceFake : IUserService
{

    public bool IsAuthenticated => true;

    public string UserId => "user@blazingpizza.com";

    public string FullName => "Sergi Ortiz";
}
