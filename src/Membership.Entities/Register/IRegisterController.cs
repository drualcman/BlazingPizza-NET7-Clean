using Membership.Entities.Dtos;

namespace Membership.Entities.Register;
public interface IRegisterController
{
    Task RegisterAsync(UserForRegistrationDto userData);
}
