using Catalog.Application.Interfaces;
using Catalog.Application.Services;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Catalog.Application.Extensions
{
    public static class InjectionExtension
    {
        public static IServiceCollection AddInjectionApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);

            services.AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblies(
                    AppDomain.CurrentDomain.GetAssemblies()
                    .Where(p => !p.IsDynamic)
                    );
            });

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<ITechnologyApplication, TechnologyApplication>();
            services.AddScoped<IUserApplication,UserApplication>();
            
            return services;
        }
    }
}
