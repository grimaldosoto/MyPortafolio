using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

namespace Catalog.API.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            var openApi = new OpenApiInfo
            {
                Title = "Catalog  API",
                Version = "v1",
                Description = "Lista de proyectos realizados ",
                TermsOfService = new Uri("https://opensource.org/licences/MIT"),
                Contact = new OpenApiContact
                {
                    Name = "SAC",
                    Email = "rdd.@sac.com",
                    Url = new Uri("https://www.sac.com.pe")
                },
                License = new OpenApiLicense
                {
                    Name = "Use under Lic",
                    Url = new Uri("https://opensource.org/licences/MIT")
                }
            };

            services.AddSwaggerGen(x =>
            {
                openApi.Version = "v1";
                x.SwaggerDoc("v1", openApi);

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Jwt Authentication",
                    Description = "Jwt Bearer Token",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                x.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { securityScheme, new string[]{} }
                });
            });

            return services;
        }
    }
}
