using Membership.Entities.Dtos;

namespace Membership.Entities.Register;
public interface IRegisterInputPort
{
    Task RegisterAsync(UserForRegistrationDto userData);
}
