using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlacementPortal.Application.Interfaces.Repositories;
using PlacementPortal.Infrastructure.Common;

namespace PlacementPortal.Infrastructure
{
    public static class InfrastructureExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection service, ConfigurationManager configuration)
        {
            service.AddDbContext<ApplicationDbContext>(Options => 
                        Options.UseSqlServer(configuration.GetConnectionString("ApplicationDbConfig")));

            service.AddTransient<IUnitOfWork, UnitOfWork>();

            return service;
        }
    }
}
