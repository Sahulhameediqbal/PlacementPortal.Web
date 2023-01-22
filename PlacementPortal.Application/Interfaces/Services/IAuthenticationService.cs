using PlacementPortal.Model.Models;

namespace PlacementPortal.Application.Interfaces.Services
{
    public interface IAuthenticationCustomService
    {
        Task<AuthenticationModel> Login(LoginModel login);
        Task<AuthenticationModel> Register(RegisterModel register);
    }
}
