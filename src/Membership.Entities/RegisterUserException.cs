namespace Membership.Entities;
public class RegisterUserException : Exception
{
    public List<string> Errors { get; }
    public RegisterUserException() { }

    public RegisterUserException(string message) : base(message) { }

    public RegisterUserException(string message, Exception innerException) : base(message, innerException) { }

    public RegisterUserException(List<string> errors) : base("Erro de registro de usuario.") => Errors = errors;
}
