using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlacementPortal.Application.Common;
using PlacementPortal.Application.Interfaces.Services;
using PlacementPortal.Application.Services;

namespace PlacementPortal.Application
{
    public static class ApplicationExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection service, ConfigurationManager configuration)
        {
            
            service.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            service.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            service.AddScoped<IAuthenticationService, AuthenticationService>();
            service.AddScoped<IUserService, UserService>();
            return service;
        }
      

    }
}
