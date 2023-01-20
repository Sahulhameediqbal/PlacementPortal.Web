using PlacementPortal.Model.Models;

namespace PlacementPortal.Application.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<AuthenticationModel> Login(LoginModel login);
        Task<AuthenticationModel> Register(RegisterModel register);
    }
}
