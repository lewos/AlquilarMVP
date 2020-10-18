using AlquilarMVP.API.Models;
using AlquilarMVP.API.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AlquilarMVP.API.IoC
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Extension that configures the DB
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddDbSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AlquilarDatabaseSettings>(
                configuration.GetSection(nameof(AlquilarDatabaseSettings)));

            return services;
        }


        /// <summary>
        /// Extension that register all the interfaces and their implementations
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            // requires using Microsoft.Extensions.Options
            services.AddSingleton<IAlquilarDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<AlquilarDatabaseSettings>>().Value);

            services.AddSingleton<PropertyService>();

            return services;
        }

        public static IServiceCollection AddOpenAPIGen(this IServiceCollection services)
        {
            //services.AddSwaggerGen();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            return services;
        }

    }
}
