namespace Membership.Blazor.UI.Models;
internal class UserCredentials
{
    [Required(ErrorMessage = "El correo es requerido.")]
    public string UserName { get; set; } 
    [Required(ErrorMessage = "La contraseña es requerida.")]
    public string Password { get; set; }
}
