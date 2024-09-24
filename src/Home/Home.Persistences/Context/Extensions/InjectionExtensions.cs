using Microsoft.Extensions.DependencyInjection;

namespace Home.Persistences.Context.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionPersistence(this IServiceCollection services)
        {
            services.AddSingleton<ApplicationDbContext>();
            return services;
        }
    }
}
