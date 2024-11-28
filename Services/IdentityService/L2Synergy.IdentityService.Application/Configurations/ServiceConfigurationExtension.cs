using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using L2Synergy.IdentityService.Application.TokenService;
using L2Synergy.IdentityService.Application.TokenService.Options;
using L2Synergy.IdentityService.Infrastructure.Options;
using L2Synergy.IdentityService.Infrastructure.Repositories.Contracts;
using L2Synergy.IdentityService.Infrastructure.Repositories.Implementations;
using System.Reflection;


namespace L2Synergy.IdentityService.Application.Configurations
{
    public static class ServiceConfigurationExtension
    {
        public static void AddApplicationService(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoOption>(configuration.GetSection(nameof(MongoOption)));
            services.AddSingleton<IMongoOption>(sp => sp.GetRequiredService<IOptions<MongoOption>>().Value);
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            //version vieja de MediatR
            //services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.Configure<TokenOption>(configuration.GetSection(nameof(TokenOption)));
            services.AddSingleton<ITokenOption>(sp => sp.GetRequiredService<IOptions<TokenOption>>().Value);
            services.AddScoped<ITokenGenerator, TokenGenerator>();
        }
    }

}
