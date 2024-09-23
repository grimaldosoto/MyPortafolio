using Catalog.Application.Commons.Ordering;
using Catalog.Application.Extensions.WatchDog;
using Catalog.Application.Interfaces;
using Catalog.Application.Services;
using FluentValidation;
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

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddWatchDog(configuration);

            services.AddScoped<IGenerateExcelApplication, GenerateExcelApplication>();
            services.AddTransient<IOrderingQuery, OrderingQuery>();

            services.AddScoped<ITechnologyApplication, TechnologyApplication>();
            services.AddScoped<IUserApplication,UserApplication>();
            services.AddScoped<ITechStackAppApplication, TechStackAppApplication>();
            
            return services;
        }
    }
}
